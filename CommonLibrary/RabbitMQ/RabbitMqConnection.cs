using System;
using System.Collections.Generic;
using System.Text;

namespace QI.Core.MessageQueue
{
    public class RabbitMqConnection
    {
        public string HostName { get; set; }

        public int Port { get; set; } = 15672;

        public string UserName { get; set; }

        public string Password { get; set; }

        public string VirtualHost { get; set; } = "/";

        public int ContinuationTimeout { get; set; } = 10;
        public int Topics { get; set; } = 10;
    }
}
