using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi24.Servicios.Viajes.Entities;

namespace Taxi24.Servicios.Viajes.MQ
{
    public class MqClient
    {
        private IConfiguration _configuration;
        private readonly ILogger<MqClient> _logger;
        public MqClient(IConfiguration configuration, ILogger<MqClient> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public void BroadcastViajeCompletado(Viaje viaje)
        {
            _logger.LogInformation("Enviando Mensaje");

            var factory = new ConnectionFactory() { HostName = _configuration["QueueHostname"] };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "taxi24_viaje_completado",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(viaje);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "taxi24_viaje_completado",
                                     basicProperties: null,
                                     body: body);
                _logger.LogInformation("Mensaje Enviado");

            }
        }

    }
}
