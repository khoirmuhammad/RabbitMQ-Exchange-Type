using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQConsumer
{
    internal class ConsumerDirectExchangeType
    {

        public static void DefaultExchangeName(IModel channel)
        {
            channel.QueueDeclare(queue: "default", exclusive: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message received: {message}");
            };

            channel.BasicConsume(queue: "default", autoAck: true, consumer: consumer);

        }

        public static void DirectExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "direct-exchange", type: ExchangeType.Direct);

            channel.QueueDeclare(
                queue: "direct-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            channel.QueueBind(queue: "direct-queue", exchange: "direct-exchange", routingKey: "direct.init");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Message received: {message}");   
            };

            channel.BasicConsume(queue: "direct-queue", autoAck: true, consumer: consumer);

        }
    }
}
