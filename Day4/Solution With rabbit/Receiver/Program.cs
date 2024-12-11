// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Channels;

var factory = new ConnectionFactory
{
    HostName = "localhost"
};

var connection = await factory.CreateConnectionAsync();
using
var channel = await connection.CreateChannelAsync();
await channel.QueueDeclareAsync("product", exclusive: false);
var consumer = new AsyncEventingBasicConsumer(channel);
//var consumer = new EventingBasicConsumer(channel);
consumer.ReceivedAsync +=async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = System.Text.Encoding.UTF8.GetString(body);
    Console.WriteLine($" [x] Received {message}");
};

await channel.BasicConsumeAsync(queue: "product",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

