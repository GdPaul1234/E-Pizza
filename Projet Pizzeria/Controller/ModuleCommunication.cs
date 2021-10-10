using Projet_Pizzeria.Controller.Communication;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Projet_Pizzeria.Controller
{
    public class ModuleCommunication
    {
        // Topics (using the .NET client)
        // https://www.rabbitmq.com/tutorials/tutorial-five-dotnet.html
        public static void PublishMessage(string routingKey, string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "pizzeria_topic_logs", type: "topic");
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "pizzeria_topic_logs",
                                     routingKey: routingKey,
                                     basicProperties: null,
                                     body: body);

                System.Diagnostics.Trace.TraceInformation(" [x] Sent '{0}':'{1}'", routingKey, message);
            }
        }

        public delegate void DelStoreMessage(string message);

        public static void ReceiveMessage(DelStoreMessage callback, params string[] bindingKeys)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "pizzeria_topic_logs", type: "topic");
            var queueName = channel.QueueDeclare().QueueName;

            foreach (var bindingKey in bindingKeys)
            {
                channel.QueueBind(queue: queueName,
                                  exchange: "pizzeria_topic_logs",
                                  routingKey: bindingKey);
            }

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;
                callback?.Invoke(message);
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }
    }
}