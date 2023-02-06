// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQConsumer;

var factory = new ConnectionFactory { HostName = "localhost" };
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

//ConsumerDirectExchangeType.DirectExchangeName(channel);
//ConsumerTopicExchangeType.TopicExchangeName(channel);
//ConsumerHeaderExchangeType.HeaderExchangeName(channel);
ConsumerFanoutExchangeType.FanoutExchangeName(channel);

Console.ReadKey();
