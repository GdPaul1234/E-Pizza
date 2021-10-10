using System;
using System.Text;
using RabbitMQ.Client;

namespace Projet_Pizzeria.Controller
{
    public class MessageReceiver : DefaultBasicConsumer
    {
        private readonly IModel _channel;
        public string message;
        public MessageReceiver(IModel channel)
        {
            _channel = channel;
        }
        public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> body)
        {
            Console.WriteLine($"Consuming Message");
            Console.WriteLine(string.Concat("Message received from the exchange ", exchange));
            Console.WriteLine(string.Concat("Consumer tag: ", consumerTag));
            Console.WriteLine(string.Concat("Delivery tag: ", deliveryTag));
            Console.WriteLine(string.Concat("Routing tag: ", routingKey));
            message = Encoding.UTF8.GetString(body.ToArray());
            Console.WriteLine(string.Concat("Message: ", message));
            _channel.BasicAck(deliveryTag, false);
        }

    }
}
