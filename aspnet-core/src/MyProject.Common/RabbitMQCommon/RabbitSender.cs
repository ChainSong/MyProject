using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyProject.Common.RabbitMQCommon
{
    public   class RabbitSender
    {
        private static IModel _channel;
        private static readonly object Object = new object();
        private   RabbitSenderOption option;
        public   RabbitSender(RabbitSenderOption rso)
        {
            this.option = rso;
            Conn(option);
            _channel.ExchangeDeclare(exchange: option.ExchangeName, type: "direct", durable: true, autoDelete: false, arguments: null);
            //QueueArguments就是上面为优先级定义的这个dictionary
            _channel.QueueDeclare(queue: option.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: QueueArguments);
            _channel.QueueBind(queue: option.QueueName, exchange: option.ExchangeName, routingKey: option.RoutingKey);
        }
        internal static IDictionary<string, object> QueueArguments
        {
            get
            {
                IDictionary<string, object> arguments = new Dictionary<string, object>();
                //arguments["x-max-priority"] = 10;//定义队列优先级为10个级别
                return arguments;
            }
        }
        public  void Send()
        {
            //Conn(option);
            //_channel.QueueDeclare(queue: option.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: QueueArguments);
            var properties = GetProperties(option);
            //var jsonSettings = RabbitJsonHelper.GetJsonSerializerSettings(option.EventName);
            var content = option.Message;// JsonContent.Create(option.Message, jsonSettings);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(content));
            _channel.BasicPublish(option.ExchangeName, option.RoutingKey, properties, body);
        }
        /// <summary>
        /// 队列初始化
        /// </summary>

        public static void SendBatch(RabbitSenderOption option, IList<string> contentList)
        {
            Conn(option);
            var properties = GetProperties(option);
            foreach (var con in contentList)
            {
                var body = Encoding.UTF8.GetBytes(con);
                _channel.BasicPublish(option.ExchangeName, option.RoutingKey, properties, body);
            }
        }

        private static void Conn(RabbitSenderOption option)
        {
            if (option == null) return;
            if (string.IsNullOrEmpty(option.RoutingKey))
            {
                option.RoutingKey = option.QueueName;
            }
            if (_channel == null)
            {
                lock (Object)
                {
                    if (_channel == null)
                    {
                        try
                        {
                            _channel = RabbitConfig.Connection.CreateModel();
                        }
                        catch (Exception exception)
                        {
                            RabbitConfig.ProcessException(exception);
                            _channel = RabbitConfig.Connection.CreateModel();
                        }
                    }
                }
            }
        }

        private static IBasicProperties GetProperties(RabbitSenderOption option)
        {
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;
            //properties.Priority = option.Priority;
            properties.Headers = option.Headers;
            properties.ContentType = string.IsNullOrWhiteSpace(option.ContentType)
                ? "application/json"
                : option.ContentType;
            properties.ReplyTo = option.ReplyTo;
            properties.CorrelationId = option.CorrelationId;
            return properties;
        }
    }
}
