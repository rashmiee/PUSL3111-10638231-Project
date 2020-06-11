using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPT_API_WebConsumer.IPTModelParser;

namespace IPT_API_WebConsumer
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strEmail = email.Text;
            string strPass = pass.Text;

            STUDENT_MAST Details = new STUDENT_MAST();

            Details = SendData(strEmail, strPass);

            if(Details.STUDENT_USERNAME != "")
            {
                Response.Redirect("About.aspx");
            }
        }

        public STUDENT_MAST SendData(string strEmail, string strPass)
        {
            string pwHash = FormsAuthentication.HashPasswordForStoringInConfigFile(strPass, "sha1");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("GetStudentByUsernamePwd?STUDENT_EMAIL="+ strEmail + "&STUDENT_PASSWORD="+ pwHash + "");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            STUDENT_MAST Details = (new JavaScriptSerializer()).Deserialize<STUDENT_MAST>(result);

            return Details;
        }
    }
}