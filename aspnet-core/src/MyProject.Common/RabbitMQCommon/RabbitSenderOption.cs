using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.RabbitMQCommon
{
    public class RabbitSenderOption
    {
        public RabbitSenderOption(object message, string eventName, string queueName, string routingKey, string exchangeName, byte priority)
            : this(message, eventName, queueName, routingKey, "", "", exchangeName, priority)
        {
        }

        public RabbitSenderOption(object message, string eventName, string queueName, string routingKey, string replyTo,
            string correlationId, string exchangeName, byte priority)
            : this(message, eventName, queueName, routingKey, replyTo, correlationId, exchangeName, "", null, null)         //, priority
        {
        }

        public RabbitSenderOption(object message, string eventName, string queueName, string routingKey, string replyTo,
            string correlationId, string exchangeName, string exchangeType, string contentType,
            IDictionary<string, object> headers)               //, byte priority
        {
            Message = message;
            EventName = eventName;
            QueueName = queueName;
            RoutingKey = routingKey;
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
            ContentType = contentType;
            Headers = headers;
            ReplyTo = replyTo;
            CorrelationId = correlationId;
            //Priority = priority;
        }

        public object Message { get; set; }
        public string EventName { get; set; }
        public IDictionary<string, object> Headers { get; set; }
        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public string ContentType { get; set; }
        public string ReplyTo { get; set; }
        public string CorrelationId { get; set; }
        //public byte Priority { get; set; }
    }
}
