using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPT_WebAPI.Models;
using System.Data;

namespace IPT_WebAPI.Controllers
{
    public class StudentController : ApiController
    {
        IPT_DATABASEEntities1 entites = new IPT_DATABASEEntities1();

        [Route("RegisterNewStudent")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult RegisterNewMember([FromUri]string STUDENT_ID, string STUDENT_NAME, string STUDENT_COURSE, string STUDENT_USERNAME, string STUDENT_PASSWORD, string STUDENT_EMAIL, string STUDENT_PROF_PIC)
        {
            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             select info);

                STUDENT_MAST Details = new STUDENT_MAST();

                Details.STUDENT_ID = STUDENT_ID;
                Details.STUDENT_NAME = STUDENT_NAME;
                Details.STUDENT_COURSE = STUDENT_COURSE;
                Details.STUDENT_USERNAME = STUDENT_USERNAME;
                Details.STUDENT_PASSWORD = STUDENT_PASSWORD;
                Details.STUDENT_EMAIL = STUDENT_EMAIL;
                Details.IS_APPROVED = 0;
                Details.STUDENT_PROF_PIC = STUDENT_PROF_PIC;
                Details.USER_TYPE = "STD";

                entites.STUDENT_MAST.Add(Details);
                entites.SaveChanges();

                return Ok(true);

            }
        }

        [Route("ApproveStudent")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult ApproveStudent([FromUri]string STUDENT_ID, string APPROVED_USER, DateTime IS_APPROVED_DATE)
        {
            STUDENT_MAST Details = new STUDENT_MAST();

            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.STUDENT_ID == STUDENT_ID
                             select info);
                if (query.Any())
                {
                    Details = query.First();
                    Details.IS_APPROVED_BY = APPROVED_USER;
                    Details.IS_APPROVED_DATE = IS_APPROVED_DATE;
                    Details.IS_APPROVED = 1;

                    entites.SaveChanges();
                }
                

                return Ok(true);

            }
        }


        [Route("AddStudentCatogaries")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult AddStudentCatogaries([FromUri]string STUDENT_ID, string STUDENT_QUALIFICATIONS)
        {
            STUDENT_DETAILS Details = new STUDENT_DETAILS();

            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.STUDENT_ID == STUDENT_ID &&
                             info.IS_APPROVED == 1
                             select info);
                if (query.Any())
                {
                    Details.STUDENT_ID = STUDENT_ID;
                    Details.STUDENT_QUALIFICATIONS = STUDENT_QUALIFICATIONS;
                    entites.STUDENT_DETAILS.Add(Details);
                    entites.SaveChanges();
                }


                return Ok(true);

            }
        }

        [Route("GetApprovedStudents")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetApprovedStudents()
        {
            List<STUDENT_MAST> Details = new List<STUDENT_MAST>();
             

            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.IS_APPROVED == 1
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }


                return Ok(Details);

            }
        }



        [Route("GetUnApprovedStudents")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetUnApprovedStudents()
        {
            List<STUDENT_MAST> Details = new List<STUDENT_MAST>();


            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.IS_APPROVED == 0
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }


                return Ok(Details);

            }
        }


        [Route("GetApprovedStudentsTwoColumns")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetApprovedStudentsTwoColumns()
        {
            //List<STUDENT_MAST> Details = new List<STUDENT_MAST>();

            DataTable dt = new DataTable();

            STUDENT_MAST[] Details;

            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.IS_APPROVED == 1
                             select info);
                if (query.Any())
                {
                     Details = query.ToList().ToArray();

                    foreach (STUDENT_MAST items in Details)
                    {
                        DataRow row = dt.NewRow();
                        row["ItemCode"] = items.STUDENT_ID;
                        row["ItemDesc"] = items.STUDENT_NAME;
                        dt.Rows.Add(row);
                    }
                }

                return Ok(dt);

            }
        }



        [Route("GetStudentByUsernamePwd")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetStudentByUsernamePwd([FromUri]string STUDENT_EMAIL, string STUDENT_PASSWORD)
        {
            STUDENT_MAST Details = new STUDENT_MAST();
            

            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             where info.IS_APPROVED == 1 &&
                             info.STUDENT_EMAIL == STUDENT_EMAIL &&
                             info.STUDENT_PASSWORD == STUDENT_PASSWORD
                             select info);
                if (query.Any())
                {
                    Details = query.First();
                }

                return Ok(Details);

            }
        }

        [Route("GetAllStudents")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetAllStudents()
        {
            List<STUDENT_MAST> Details = new List<STUDENT_MAST>();


            using (entites)
            {
                var query = (from info in entites.STUDENT_MAST
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }


                return Ok(Details);

            }
        }

    }
}
