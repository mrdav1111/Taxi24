# Taxi24

Pasos para ejecutar el proyecto:

 1. Abrir una consola en el directorio donde se encuentra la solución
 2. Ejecutar el comando `docker compose up -d`

Esta acción creara un contenedor para cada microservicio, para el gateway y para los componentes de base de datos y RabbitMQ.

El proyecto esta configurado de tal forma que expone dos puertos al host:

 - El puerto 8080 donde el API Gateway expone los métodos via REST.
 - El puerto 15432 donde se expone PgAdmin4 para gestionar la base de datos de forma directa.

El API Gateway tiene Swagger configurado en el endpoint `/swagger`.

Las credenciales para el PgAdmin son Usuario: admin@db.com y contraseña: admin123.

Los parámetros para conectarse a la base de datos Postgresql son los siguientes:

 - Hostname: database
 - User: postgres
 - Password: besttaxiservice24

Antes de ejecutar algún método de la REST API se deben crear las bases de datos con los Scripts proporcionados.

Se deben crear 4 bases de datos con los siguientes nombres:

 1. `Taxi24.Conductores`
 2. `Taxi24.Facturas`
 3. `Taxi24.Pasajeros`
 4. `Taxi24.Viajes`


Y restaurar cada una con el archivo del mismo nombre en la carpeta `Database`
