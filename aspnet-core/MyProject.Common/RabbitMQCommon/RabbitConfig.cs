using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.RabbitMQCommon
{
    public class RabbitConfig
    {
        private static readonly string RabbitPath; //@"E:\Program Files\RabbitMQ Server\rabbitmq_server-3.6.0\sbin";
        private static readonly ConnectionFactory Factory = new ConnectionFactory();
        private static IConnection _connection;
        private static readonly object Obj = new object();

        static RabbitConfig()
        {
            //RabbitPath = ConfigurationManager.AppSettings["rabbitPath"];
            ConfigFactory();
        }

        public static IConnection Connection
        {
            get
            {
                if (_connection != null && _connection.IsOpen) return _connection;
                lock (Obj)
                {
                    if (_connection == null || !_connection.IsOpen)
                    {
                        ReConnect();
                    }
                }
                return _connection;
            }
        }

        private static void ConfigFactory()
        {
            Factory.HostName ="10.77.77.173";
            Factory.Port =5672;
            Factory.UserName ="lijie"; 
            Factory.Password = "yingqidm"; 
            //Factory.VirtualHost = "intewareIP";
            //Factory.RequestedHeartbeat = 30;
            //Factory.RequestedConnectionTimeout = 3000;
        }


        public static void ReConnect()
        {
            ConfigFactory();
            _connection = Factory.CreateConnection();
        }

        //public static void Restart()
        //{
        //    Process("remove");
        //    Process("install");
        //    Process("start");
        //}

        //private static void Process(string arguments)
        //{
        //    var process = new Process();
        //    var startInfo = new ProcessStartInfo
        //    {
        //        WindowStyle = ProcessWindowStyle.Hidden,
        //        WorkingDirectory = RabbitPath,
        //        FileName = "rabbitmq-service.bat",
        //        Arguments = arguments
        //    };
        //    process.StartInfo = startInfo;
        //    process.Start();
        //    process.WaitForExit();
        //}


        public static void ProcessException(Exception exception)
        {
            if (_connection != null)
            {
                _connection.Dispose();
            }
            //if (exception is BrokerUnreachableException)
            //{
            //    Restart();
            //}
            try
            {
                ReConnect();
            }
            catch (Exception)
            {
                throw new Exception("连接MQ失败");
            }
        }
    }
}
