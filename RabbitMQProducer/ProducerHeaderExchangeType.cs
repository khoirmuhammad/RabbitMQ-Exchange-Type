using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    internal class ProducerHeaderExchangeType
    {
        public static void HeaderExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "header-exchange", type: ExchangeType.Headers);

            var message = new { Name = "Producer", Message = "Hello! this is header exchange" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            var properties = channel.CreateBasicProperties();
            properties.Headers = new Dictionary<string, object> { { "header1", "init" }, { "header2", "init" } };

            channel.BasicPublish(exchange: "header-exchange", routingKey: "", basicProperties: properties, body: body);

        }
    }
}
