using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    internal class ProducerFanoutExchangeType
    {
        public static void FanoutExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "fanout-exchange", type: ExchangeType.Fanout);

            var message = new { Name = "Producer", Message = "Hello! this is fanout exchange" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish(exchange: "fanout-exchange", routingKey: "", basicProperties: null, body: body);

        }
    }
}
