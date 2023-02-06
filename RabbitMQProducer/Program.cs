// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQProducer;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

//ProducerDirectExchangeType.DirectExchangeName(channel);
//ProducerTopicExchangeType.TopicExchangeName(channel);
//ProducerHeaderExchangeType.HeaderExchangeName(channel);
ProducerFanoutExchangeType.FanoutExchangeName(channel);

Console.ReadKey();
