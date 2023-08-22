using log4net;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using QI.Core.Model;
using QI.Core.Utils;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QI.Core.MessageQueue
{

    public interface ITopicExchangeClient
    {
        void PublishMessage(QueueMessage queueMessage, string routingKey);
        void SubscribeMessage(Action<QueueMessage> func);
    }
    public class TopicExchangeClient : ITopicExchangeClient, IDisposable
    {
        private RabbitMqConnection rabbitmqConnection;
        private IConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;
        private IBasicProperties publishWorkerProperties;
        private readonly IZipHelper zipHelper;
        //private readonly ILogger<RabbitMqClient> logger;
        public virtual string topic { get; set; }
        public TopicExchangeClient(IOptions<RabbitMqConnection> options, IZipHelper _zipHelper)
        {
            this.rabbitmqConnection = options.Value;
            this.zipHelper = _zipHelper;
            //this.logger = _logger;
            OpenConnectionAsync().Wait();
        }
        public Task<bool> OpenConnectionAsync()
        {
            try
            {
                if (connection != null && channel != null && connection.IsOpen && channel.IsOpen)
                    return Task.FromResult(true);
                else
                {
                    connectionFactory = new ConnectionFactory()
                    {
                        HostName = rabbitmqConnection.HostName,
                        //Port = rabbitmqConnection.Port,
                        UserName = rabbitmqConnection.UserName,
                        Password = rabbitmqConnection.Password,
                        //VirtualHost = rabbitmqConnection.VirtualHost,
                        ContinuationTimeout = new TimeSpan(0, 0, 0, rabbitmqConnection.ContinuationTimeout)
                    };
                    connection = connectionFactory.CreateConnection();
                    channel = connection.CreateModel();
                    channel.ExchangeDeclare(exchange: topic, type: "topic");
                    publishWorkerProperties = channel.CreateBasicProperties();
                    publishWorkerProperties.Persistent = true;
                    return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "Connected Rabbit Error", rabbitmqConnection);
                return Task.FromResult(false);
            }
        }

        public virtual void PublishMessage(QueueMessage queueMessage, string routingKey)
        {
            var body = zipHelper.ZipByte(JsonSerializer.SerializeToUtf8Bytes(queueMessage));

            try
            {
                if (OpenConnectionAsync().Result)
                {
                    channel.BasicPublish(exchange: topic, routingKey: routingKey, basicProperties: publishWorkerProperties, body: body);
                }

            }
            catch
            {

            }
            finally
            {

            }
        }
        public virtual void SubscribeMessage(Action<QueueMessage> func)
        {

        }


        public void Dispose()
        {
            connection.Dispose();
            channel.Dispose();
        }
    }


    public class TopicReceiveClient
    {
        private RabbitMqConnection rabbitmqConnection;
        private IConnectionFactory connectionFactory;
        private IConnection connection;
        private IModel channel;
        private IBasicProperties publishWorkerProperties;
        private readonly IZipHelper zipHelper;
        private readonly ILogger logger;
        protected string topic { get; set; }
        protected string queueName { get; set; }
        public TopicReceiveClient(string queueName, string topic, RabbitMqConnection _rabbitmqConnection, IZipHelper _zipHelper, ILogger _logger)
        {
            this.rabbitmqConnection = _rabbitmqConnection;
            this.zipHelper = _zipHelper;
            this.logger = _logger;
            this.topic = topic;
            this.queueName = queueName;
            OpenConnectionAsync().Wait();
        }
        public Task<bool> OpenConnectionAsync()
        {
            try
            {
                if (connection != null && channel != null && connection.IsOpen && channel.IsOpen)
                    return Task.FromResult(true);
                else
                {
                    connectionFactory = new ConnectionFactory()
                    {
                        HostName = rabbitmqConnection.HostName,
                        //Port = rabbitmqConnection.Port,
                        UserName = rabbitmqConnection.UserName,
                        Password = rabbitmqConnection.Password,
                        //VirtualHost = rabbitmqConnection.VirtualHost,
                        ContinuationTimeout = new TimeSpan(0, 0, 0, rabbitmqConnection.ContinuationTimeout)
                    };
                    connection = connectionFactory.CreateConnection();
                    channel = connection.CreateModel();
                    channel.ExchangeDeclare(exchange: topic, type: "topic");
                    channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueBind(queue: queueName, exchange: topic, routingKey: queueName);
                    publishWorkerProperties = channel.CreateBasicProperties();
                    publishWorkerProperties.Persistent = true;
                    return Task.FromResult(true);
                }
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "Connected Rabbit Error", rabbitmqConnection);
                return Task.FromResult(false);
            }
        }

        public virtual void PublishMessage(QueueMessage queueMessage, string routingKey)
        {
            var body = zipHelper.ZipByte(JsonSerializer.SerializeToUtf8Bytes(queueMessage));

            try
            {
                if (OpenConnectionAsync().Result)
                {
                    channel.BasicPublish(exchange: topic, routingKey: routingKey, basicProperties: publishWorkerProperties, body: body);
                }

            }
            catch
            {

            }
            finally
            {

            }
        }
        public virtual void SubscribeMessage(Action<QueueMessage> func)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var message = JsonSerializer.Deserialize<QueueMessage>(zipHelper.UnZipByte(ea.Body.ToArray()));
                    func(message);
                }
                catch (Exception ex)
                {
                    //logger.LogError(ex, "Run SubscribeWorkerTask error");
                }
                finally
                {
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
            };
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
        }


        public void Dispose()
        {
            connection.Dispose();
            channel.Dispose();
        }
    }
}
