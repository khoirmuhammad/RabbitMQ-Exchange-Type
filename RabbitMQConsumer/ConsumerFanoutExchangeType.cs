using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class ConsumerFanoutExchangeType
    {
        public static void FanoutExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "fanout-exchange", type: ExchangeType.Fanout);

            channel.QueueDeclare(
                queue: "fanout-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(queue: "fanout-queue", exchange: "fanout-exchange", routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "fanout-queue", autoAck: true, consumer: consumer);

        }
    }
}
