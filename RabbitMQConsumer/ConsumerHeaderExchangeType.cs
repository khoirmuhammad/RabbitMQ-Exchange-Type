using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class ConsumerHeaderExchangeType
    {
        public static void HeaderExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "header-exchange", type: ExchangeType.Headers);

            channel.QueueDeclare(
                queue: "header-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var header = new Dictionary<string, object> { { "header1", "init" }};

            channel.QueueBind(queue: "header-queue", exchange: "header-exchange", routingKey: "", arguments: header);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "header-queue", autoAck: true, consumer: consumer);

        }
    }
}
