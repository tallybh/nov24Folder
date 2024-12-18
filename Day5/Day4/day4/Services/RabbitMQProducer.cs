using day4.Contracts;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace day4.Services
{
    public class RabbitMQProducer : IRabbitMQ
    {
        public async Task SendProductMessageAsync<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672, UserName = "guest", Password = "guest" };
            var connection = await factory.CreateConnectionAsync();
            using
            var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync("product", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            await channel.BasicPublishAsync(exchange: "", routingKey: "product", body: body);
        }
    }
}

 

