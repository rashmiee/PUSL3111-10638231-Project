using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPT_API_WebConsumer.IPTModelParser;

namespace IPT_API_WebConsumer
{
    public partial class StudentsList : System.Web.UI.Page
    {
        string SystemUserDetails = "ST009";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUnaprrovedStd();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = InvDetailsGrid.Rows[rowIndex];
            string code = (row.FindControl("lblStdId") as Label).Text;

            bool status = ApproveStd(code, SystemUserDetails);

            if (status== true){

                LoadUnaprrovedStd();
            }
        }

        protected void LoadUnaprrovedStd()
        {
            List<STUDENT_MAST> Details = new List<STUDENT_MAST>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("GetUnApprovedStudents");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            Details = (new JavaScriptSerializer()).Deserialize<List<STUDENT_MAST>>(result);

            InvDetailsGrid.DataSource = Details;
            InvDetailsGrid.DataBind();
        }

        protected bool ApproveStd(string stdId, string SystemUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("ApproveStudent?STUDENT_ID="+ stdId+"&APPROVED_USER="+ SystemUser + "&IS_APPROVED_DATE="+DateTime.Today+"");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            bool status = (new JavaScriptSerializer()).Deserialize<bool>(result);

            return status;
        }
        
    }
}