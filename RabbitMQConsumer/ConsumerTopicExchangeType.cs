using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class ConsumerTopicExchangeType
    {
        public static void TopicExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "topic-exchange", type: ExchangeType.Topic);

            channel.QueueDeclare(
                queue: "topic-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(queue: "topic-queue", exchange: "topic-exchange", routingKey: "topic.*");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "topic-queue", autoAck: true, consumer: consumer);

        }
    }
}
