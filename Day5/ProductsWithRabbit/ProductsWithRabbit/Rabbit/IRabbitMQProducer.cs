namespace ProductsWithRabbit.Rabbit
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message);
    }
}
