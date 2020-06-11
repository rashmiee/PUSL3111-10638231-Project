using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace IPT_API_WebConsumer
{
    public partial class Signup : System.Web.UI.Page
    {
        public static string EndPoint = "http://localhost/IPTWebAPI";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string apiUrl = "http://localhost/IPTWebAPI";
            //int input = 1;

            //string inputJson = (new JavaScriptSerializer()).Serialize(input);
            //WebClient client = new WebClient();

            //client.Headers["Content-type"] = "application/json";
            //client.Encoding = Encoding.UTF8;
            //string Result = client.UploadString(apiUrl + "/api/Student", inputJson);

            //string x = (new JavaScriptSerializer()).Deserialize<string>(Result);
            //Label1.Text = x;
            LoadData(1);


        }

        public void LoadData(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("api/Student/1");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            string x = (new JavaScriptSerializer()).Deserialize<string>(result);

            Label1.Text = x;
        }


      

    }
}