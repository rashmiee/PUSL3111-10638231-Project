//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPT_WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class IT_EXPERT_MAST
    {
        public string IT_EXPERT_USERNAME { get; set; }
        public string IT_EXPERT_PASSWORD { get; set; }
        public string IT_EXPERT_EMAIL { get; set; }
        public string IT_EXPERT_COMPANY { get; set; }
        public string IT_EXPERT_EXPERT_AREA { get; set; }
        public Nullable<short> IS_APPROVED { get; set; }
        public string IS_APPROVED_BY { get; set; }
        public Nullable<System.DateTime> IS_APPROVED_DATE { get; set; }
        public string PROF_PIC_URL { get; set; }
        public string USER_TYPE { get; set; }
        public int AUTO_NUM { get; set; }
    }
}