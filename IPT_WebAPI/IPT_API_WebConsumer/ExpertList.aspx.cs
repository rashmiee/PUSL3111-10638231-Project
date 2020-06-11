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
    public partial class ExpertList : System.Web.UI.Page
    {
        string SystemUserDetails = "ST009";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUnaprrovedStd();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as Button).NamingContainer as GridViewRow).RowIndex);
            GridViewRow row = ExpertDetailsGrid.Rows[rowIndex];
            string code = (row.FindControl("lblGridUsername") as Label).Text;

            bool status = ApproveStd(code, SystemUserDetails);

            if (status == true)
            {

                LoadUnaprrovedStd();
            }
        }

        protected void LoadUnaprrovedStd()
        {
            List<IT_EXPERT_MAST> Details = new List<IT_EXPERT_MAST>();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("GetApprovedItExperts");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            Details = (new JavaScriptSerializer()).Deserialize<List<IT_EXPERT_MAST>>(result);

            ExpertDetailsGrid.DataSource = Details;
            ExpertDetailsGrid.DataBind();
        }

        protected bool ApproveStd(string stdId, string SystemUser)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("ApproveItExpert?IT_EXPERT_USERNAME=" + stdId + "&APPROVED_USER=" + SystemUser + "&IS_APPROVED_DATE=" + DateTime.Today + "");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            bool status = (new JavaScriptSerializer()).Deserialize<bool>(result);

            return status;
        }
    }
}