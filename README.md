# Taxi24

Pasos para ejecutar el proyecto:

 1. Abrir una consola en el directorio donde se encuentra la solución
 2. Ejecutar el comando `docker compose up -d`

Esta acción creara un contenedor para cada microservicio, para el gateway y para los componentes de base de datos y RabbitMQ.

El proyecto esta configurado de tal forma que expone dos puertos al host:

 - El puerto 8080 donde el API Gateway expone los métodos via REST.
 - El puerto 15432 donde se expone PgAdmin4 para gestionar la base de datos de forma directa.

Las credenciales para el PgAdmin son Usuario: admin@db.com y contraseña: admin123.

Los parámetros para conectarse a la base de datos Postgresql son los siguientes:

 - Hostname: database
 - User: postgres
 - Password: besttaxiservice24

Antes de ejecutar algún método de la REST API se deben crear las bases de datos con los Scripts proporcionados.
