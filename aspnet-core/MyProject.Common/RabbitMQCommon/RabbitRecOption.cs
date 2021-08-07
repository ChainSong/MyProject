using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.RabbitMQCommon
{
    public class RabbitRecOption
    {
        public RabbitRecOption(string queueName, ushort preFetchCount = 1)
            : this(queueName, "", "", "", preFetchCount)
        {
        }

        public RabbitRecOption(string queueName, string routingKey, string exchangeName,
            string exchangeType, ushort preFetchCount)
        {
            QueueName = queueName;
            RoutingKey = routingKey;
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
            PreFetchCount = preFetchCount;
        }

        public string QueueName { get; set; }
        public string RoutingKey { get; set; }
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
        public ushort PreFetchCount { get; set; }
    }
}
