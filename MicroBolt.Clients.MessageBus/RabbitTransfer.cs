using MicroBolt.Clients.Data.Contracts.Entity;
using MicroBolt.Clients.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MicroBolt.Clients.MessageBus
{
    public class RabbitTransfer : IRabbitTransfer
    {
        public void Start(ClientModel entity)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(entity);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
