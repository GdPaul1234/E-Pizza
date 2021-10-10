using RabbitMQ.Client;
using System;
using System.Text;

namespace Projet_Pizzeria.Controller
{
    public class ModuleCommunication
    {   //Info. Connexion
        private static readonly string UserName = "guest";
        private static readonly string Password = "guest";
        private static readonly string HostName = "localhost";

        public static RabbitMQ.Client.ConnectionFactory connectionFactory = new RabbitMQ.Client.ConnectionFactory()
        { 
            UserName = ModuleCommunication.UserName,
            Password = ModuleCommunication.Password,
            HostName = ModuleCommunication.HostName
        };

        public static void SendMessage(string exchangeName, string keyRouting, string message)
        {
            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            properties.Persistent = true;
            byte[] messagebuffer = Encoding.Default.GetBytes(message);
            model.BasicPublish(exchangeName, keyRouting, properties, messagebuffer);
            Console.WriteLine("Message Sent");          
        }

        public static string ReceiveMessage(string queueName)
        {
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume(queueName, false, messageReceiver);
            return messageReceiver.message;
        }

    }
}