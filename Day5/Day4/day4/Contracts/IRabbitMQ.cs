namespace day4.Contracts
{
    public interface IRabbitMQ
    {
        Task SendProductMessageAsync<T>(T message);
    }
}
