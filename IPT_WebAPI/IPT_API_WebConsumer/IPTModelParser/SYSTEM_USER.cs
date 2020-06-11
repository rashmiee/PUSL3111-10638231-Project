using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPT_API_WebConsumer.IPTModelParser
{
    public class SYSTEM_USER
    {
        public string SU_USER_ID { get; set; }
        public string SU_USERNAME { get; set; }
        public string SU_PASSWORD { get; set; }
        public string SU_NAME { get; set; }
        public string USER_TYPE { get; set; }
        public int AUTO_NUM { get; set; }
    }
}