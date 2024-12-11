namespace MyDay2.RabbitMQ
{
    public interface IRabbitMQ
    {
        Task SendProductMessageAsync<T>(T message);
    }
}
