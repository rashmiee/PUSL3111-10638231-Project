using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPT_API_WebConsumer
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        SecurityCrypto securityCrypto = new SecurityCrypto();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (txtStdName.Text != "")
            {
                string StudentName = txtStdName.Text;
                string StudentID = txtStudentID.Text;
                string StudentUsername = txtStudentUsername.Text;
                string Email = txtEmail.Text;
                string Degree = DropDownList1.SelectedItem.ToString();

              // string ImgFile;
                string ImgPath="IMG";
                if (FileUpload1.PostedFile != null)
                {
                    //ImgFile = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //FileUpload1.SaveAs(Server.MapPath("~/images/avatar") + ImgFile);
                    //ImgPath = "images/avatar" + ImgFile;

                }

                string pwHash = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "sha1");

               status = SendData(StudentName, StudentID, StudentUsername, Email, Degree, ImgPath, pwHash);
            }
            
            if(status == true)
            {
                Response.Redirect("About.aspx");
            }
        }

        public bool SendData(string StudentName, string StudentID, string StudentUsername, string Email, string Degree, string ImgPath, string pwHash)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/IPTWebAPI/");

            Task<HttpResponseMessage> response = client.GetAsync("RegisterNewStudent?STUDENT_ID="+ StudentID + "&STUDENT_NAME="+ StudentName + "&STUDENT_COURSE="+Degree+"&STUDENT_USERNAME="+ StudentUsername + "&STUDENT_PASSWORD="+ pwHash +"&STUDENT_EMAIL="+ Email + "&STUDENT_PROF_PIC="+ ImgPath + "");
            var result = response.Result.Content.ReadAsStringAsync().Result;

            bool status = (new JavaScriptSerializer()).Deserialize<bool>(result);

            return status;
        }
    }
}