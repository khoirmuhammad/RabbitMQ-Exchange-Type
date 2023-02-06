using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQProducer
{
    internal class ProducerDirectExchangeType
    {      
        public static void DefaultExchangeName(IModel channel)
        {
            
            channel.QueueDeclare(queue: "default", exclusive: false);

            var message = new { Name = "Producer", Message = "Hello! this is default exchange" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "", routingKey: "default", body: body);

        }

        public static void DirectExchangeName(IModel channel)
        {
            channel.ExchangeDeclare(exchange: "direct-exchange", type: ExchangeType.Direct);

            var message = new { Name = "Producer", Message = "Hello! this is direct exchange" };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish(exchange: "direct-exchange", routingKey: "direct.init", basicProperties: null, body: body);

        }
    }

    

}
