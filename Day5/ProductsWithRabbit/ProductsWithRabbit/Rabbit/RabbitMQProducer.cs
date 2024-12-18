﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ProductsWithRabbit.Rabbit;

public class RabbitMQProducer:IRabbitMQProducer
{
    public void SendProductMessage<T>(T message)
    {
        var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest" , Password = "guest" };
       

        //var factory = new ConnectionFactory
        //{
        //    HostName = "localhost"
        //};
        var connection = factory.CreateConnection();
        using
        var channel = connection.CreateModel();
        channel.QueueDeclare("product", exclusive: false);
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);
        channel.BasicPublish(exchange: "", routingKey: "product", body: body);
    }

}
