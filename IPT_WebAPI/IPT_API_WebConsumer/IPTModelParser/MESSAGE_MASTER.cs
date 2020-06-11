using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPT_API_WebConsumer.IPTModelParser
{
    public class MESSAGE_MASTER
    {
        public string STUDENT_ID { get; set; }
        public string IT_EXPERT_USERNAME { get; set; }
        public string MESSAGE_BODY_STD { get; set; }
        public int AUTO_NUM { get; set; }
        public string MESSAGE_BODY_ITE { get; set; }
    }
}