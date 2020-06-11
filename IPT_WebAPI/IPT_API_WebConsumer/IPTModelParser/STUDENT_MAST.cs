using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPT_API_WebConsumer.IPTModelParser
{
    public class STUDENT_MAST
    {
        public string STUDENT_ID { get; set; }
        public string STUDENT_NAME { get; set; }
        public Nullable<int> STUDENT_AGE { get; set; }
        public string STUDENT_COURSE { get; set; }
        public string STUDENT_USERNAME { get; set; }
        public string STUDENT_PASSWORD { get; set; }
        public string STUDENT_EMAIL { get; set; }
        public short IS_APPROVED { get; set; }
        public string IS_APPROVED_BY { get; set; }
        public Nullable<System.DateTime> IS_APPROVED_DATE { get; set; }
        public string STUDENT_PROF_PIC { get; set; }
        public string USER_TYPE { get; set; }
        public int AUTO_NUM { get; set; }
    }
}