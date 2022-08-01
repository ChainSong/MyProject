using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.RabbitMQCommon
{
    public class RabbitReceiver
    {
        private readonly object _object = new object();
        private IModel _channel;
        private EventingBasicConsumer _consumer;
        private Action<BasicDeliverEventArgs> _func;
        public static IDictionary<string, IModel> connection = new Dictionary<string, IModel>();


        //public RabbitReceiver()
        //{
        //Conn();
        //connection = new Dictionary<string, IModel>();
        //connection.Add("Aden", _channel);
        //Conn();
        //connection.Add("aaa6", _channel);
        //Consume(option);
        //}

        public void Handle(Action<BasicDeliverEventArgs> callBackFunc)
        {
            _func = callBackFunc;
            //_consumer.Received += _consumer_Received;
            _consumer.Received += ((q, e) =>
            {
                if (e == null)
                {
                    return;
                }
                //var body = e.Body;
                //var content = Encoding.UTF8.GetString(body);
                _func(e);
                return;
                //if (_func(content))
                //{
                //    _channel.BasicAck(e.DeliveryTag, false);
                //}
            });
        }
        public void backAck(string channelName, ulong e)
        {
            //connection.Where(a => a.Key == channelName).Select(a => a.Value).FirstOrDefault().Close();
            //Conn();
            //connection.Where(a => a.Key == channelName).Select(a => a.Value).FirstOrDefault().BasicNack(e, false, true);
            //var consumer = new QueueingBasicConsumer(_channel);
            connection.Where(a => a.Key == channelName).Select(a => a.Value).FirstOrDefault().BasicAck(e, false);
        }
        public void CloseChannel(string channelName)
        {
            connection.Where(a => a.Key == channelName).Select(a => a.Value).FirstOrDefault().Close();
            connection.Remove(channelName);
            //Conn();
            //_channel.BasicNack(e,false,true);
            //var consumer = new QueueingBasicConsumer(_channel);
            //connection.Where(a => a.Key == "Aden").Select(a => a.Value).FirstOrDefault().BasicAck(e, false);
        }
        //private void _consumer_Received(object sender, BasicDeliverEventArgs e)
        //{
        //    if (e == null)
        //    {
        //        return;
        //    }
        //    var body = e.Body;
        //    var content = Encoding.UTF8.GetString(body);
        //    if (_func(content))
        //    {
        //        _channel.BasicAck(e.DeliveryTag, false);
        //    }
        //}

        public BasicGetResult Consume(RabbitRecOption option)
        {

            Conn(option.QueueName);
            //Consume(option);
            //int i = 0;
            //while (i < 1500)
            //{
            //    i++;
            //Conn();
            connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicQos(0, option.PreFetchCount, false);
            //if (_consumer == null)
            //{
            //    //var consumer = new QueueingBasicConsumer(_channel);
            //    _consumer = new EventingBasicConsumer(_channel);
            //}
            //_channel.BasicConsume(option.QueueName, false, _consumer);

            //var consumer = new QueueingBasicConsumer(_channel);
            //var aaaa = _channel.BasicConsume(option.QueueName, false, consumer);
            BasicGetResult msgResponse = connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicGet(queue: option.QueueName, autoAck: false);
            //_channel.BasicAck(msgResponse.DeliveryTag, false);
            //if (msgResponse != null)
            //{
            //    string msgBody = Encoding.UTF8.GetString(msgResponse.Body);
            //    //_channel.BasicAck(msgResponse.DeliveryTag, false);
            //    //Console.WriteLine(msgBody);
            //    return msgResponse;
            //}
            return msgResponse;

            //BasicGetResult msgResponse = _channel.BasicGet(queue: "test", noAck: false);
            //string msgBody = Encoding.UTF8.GetString(msgResponse.Body);
            //Console.WriteLine(msgBody);                                 
            //}
            //var msgResponse = _consumer.Queue.Dequeue(); //blocking

            //var msgBody = Encoding.UTF8.GetString(msgResponse.Body);

            //Console.WriteLine(_consumer.d);
        }
        //private readonly ConnectionFactory rabbitMqFactory;
        //List<GetMessageInfo> info = new List<GetMessageInfo>();
        //public List<GetMessageInfo> ConsumeAll(RabbitRecOption option)
        //{
        //    //Consume(option);
        //    //int i = 0;
        //    //while (i < 1500)
        //    //{
        //    //    i++;
        //    //Conn();
        //    Conn(option.QueueName);
        //    connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicQos(0, option.PreFetchCount, false);
        //    BasicGetResult msgResponse = connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicGet(queue: option.QueueName, noAck: false);


        //    if (msgResponse != null)
        //    {
        //        var msgBody = (Encoding.UTF8.GetString(msgResponse.Body)).Split(',');    // JSONStringTo<GetMessageInfo> (Encoding.UTF8.GetString(msgResponse.Body));//
        //        //info.Add(new GetMessageInfo { GoodsShelve = msgBody. });
        //        //info.Add(msgBody);
        //        //info = msgBody;
        //        GetMessageInfo f = new GetMessageInfo();
        //        //f.GoodsShelve = msgBody[0];
        //        //f.AdjustType = msgBody[1];
        //        f.goodsshelveid = msgBody[0];
        //        f.locationX = msgBody[1];
        //        f.locationY = msgBody[2];
        //        f.completiontime = Convert.ToDateTime(msgBody[3]);
        //        info.Add(f);
        //        backAck(option.QueueName, msgResponse.DeliveryTag);
        //        ConsumeAll(option);

        //    }
        //    return info;
        //}
        //public List<GetMessageInfo> ConsumeAllAGV(RabbitRecOption option)
        //{
        //    Conn(option.QueueName);
        //    connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicQos(0, option.PreFetchCount, false);
        //    BasicGetResult msgResponse = connection.Where(a => a.Key == option.QueueName).Select(a => a.Value).FirstOrDefault().BasicGet(queue: option.QueueName, noAck: false);


        //    if (msgResponse != null)
        //    {
        //        var msgBody = (Encoding.UTF8.GetString(msgResponse.Body).ToString()).Replace('"', ' ').Trim().Split(',');   // JSONStringTo<GetMessageInfo> (Encoding.UTF8.GetString(msgResponse.Body));//
        //        //info.Add(new GetMessageInfo { GoodsShelve = msgBody. });
        //        //info.Add(msgBody);
        //        //info = msgBody;
        //        GetMessageInfo f = new GetMessageInfo();
        //        f.goodsshelveid = msgBody[0];
        //        f.AdjustType = msgBody[1];
        //        info.Add(f);
        //        backAck(option.QueueName, msgResponse.DeliveryTag);
        //        ConsumeAllAGV(option);

        //    }
        //    return info;
        //}
        //public static List<T> JSONStringTo<T>(string JsonStr)
        //{
        //    JavaScriptSerializer Serializer = new JavaScriptSerializer();
        //    //return JsonConvert.DeserializeObject<List<T>>(str);
        //    List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
        //    return objs;
        //}
        private void Conn(string channelName)
        {

            if (connection.Where(a => a.Key == channelName).Count() == 0)
            {
                lock (_object)
                {
                    if (connection.Where(a => a.Key == channelName).Count() == 0)
                    {
                        try
                        {
                            _channel = RabbitConfig.Connection.CreateModel();
                            connection.Add(channelName, _channel);

                        }
                        catch (Exception exception)
                        {
                            RabbitConfig.ProcessException(exception);
                            _channel = RabbitConfig.Connection.CreateModel();
                            connection.Add(channelName, _channel);
                        }
                    }
                }

            }
        }
    }
}
