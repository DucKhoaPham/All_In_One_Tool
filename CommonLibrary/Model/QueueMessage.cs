using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace QI.Core.Model
{
    public class QueueMessage
    {
        public string Id { get; set; }
        public Dictionary<string, string> Datas { get; set; } = new Dictionary<string, string>();
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        public static QueueMessage LoadFromJson(string json)
        {
            return JsonSerializer.Deserialize<QueueMessage>(json);
        }
    }
}
