using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Taxi24.Servicios.Facturas.Model;
using Taxi24.Servicios.Facturas.Repositories;

namespace Taxi24.Servicios.Facturas.BackgroundServices
{
    public class FacturaBackgroundService : BackgroundService
    {
        private readonly ILogger _logger;
        private IServiceProvider serviceProvider;
        private IConnection connection;
        private IModel channel;
        private IConfiguration _configuration;

        public FacturaBackgroundService(ILoggerFactory loggerFactory, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<FacturaBackgroundService>();
            _configuration = configuration;
            this.serviceProvider = serviceProvider;
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            _logger.LogInformation("Iniciando BackgrondService");

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { HostName = _configuration["QueueHostname"] };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: "taxi24_viaje_completado",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                HandleMessage(message);
            };
            channel.BasicConsume(queue: "taxi24_viaje_completado",
                                 autoAck: true,
                                 consumer: consumer);


            return Task.CompletedTask;
        }

        private void HandleMessage(string content)
        {
            var viaje = JsonSerializer.Deserialize<Viaje>(content);
            _logger.LogInformation("Mensaje Parseado");

            using (var scope = serviceProvider.CreateScope())
            {
                var _facturaRespository = scope.ServiceProvider.GetRequiredService<IFacturaRespository>();
                _logger.LogInformation("Servicio Adquirido");

                _facturaRespository.Crear(new Entities.Factura
                {
                    ConductorID = viaje.PilotoID,
                    Fecha = DateTime.Now,
                    Monto = (viaje.Inicio - viaje.Final).Value.TotalMilliseconds,
                    ViajeID = viaje.ID,
                    ViajeroID = viaje.PasajeroID
                });
                _logger.LogInformation("Factura Creada");
            }



        }

        public override void Dispose()
        {
            base.Dispose();
            connection.Close();
            channel.Close();

        }
    }
}
