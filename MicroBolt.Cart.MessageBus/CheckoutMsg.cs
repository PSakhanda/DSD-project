using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

using MicroBolt.Cart.Models;

namespace MicroBolt.Cart.MessageBus
{
    public class CheckoutMsg
    {
        public void Send(CustomerCart entity)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "checkout",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(entity);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "checkout",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}
