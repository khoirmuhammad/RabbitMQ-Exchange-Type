using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    internal class ProducerTopicExchangeType
    {
        public static void TopicExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "topic-exchange", type: ExchangeType.Topic);

            var message = new { Name = "Producer", Message = "Hello! this is topic exchange" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "topic-exchange", routingKey: "topic.init", basicProperties: null, body: body);

        }
    }
}
