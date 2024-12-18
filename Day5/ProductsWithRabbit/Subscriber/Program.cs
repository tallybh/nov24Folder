﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

//var factory = new ConnectionFactory
//{
//    HostName = "localhost"
//};
var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };
var connection = factory.CreateConnection();
using
var channel = connection.CreateModel();
channel.QueueDeclare("product", exclusive: false);

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};
channel.BasicConsume(queue: "product",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();