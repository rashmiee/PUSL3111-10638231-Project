using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPT_API_WebConsumer
{
    public partial class AddCatogaries : System.Web.UI.Page
    {
        string StudID = "10638194";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            bool status = addQualifications(DropDownList1.SelectedItem.ToString(), StudID);

            if (status == true)
            {
                DropDownList1.SelectedItem.Enabled = false;
            }
           
        }

        protected bool addQualifications(string qualification, string StdId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("AddStudentCatogaries?STUDENT_ID="+ StdId + "&STUDENT_QUALIFICATIONS="+ qualification + "");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            bool status = (new JavaScriptSerializer()).Deserialize<bool>(result);

            return status;
        }
    }
}