using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPT_WebAPI.Models;

namespace IPT_WebAPI.Controllers
{
    public class CatagoryController : ApiController
    {

        IPT_DATABASEEntities1 entites = new IPT_DATABASEEntities1();

        [Route("GetAllCatogaries")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetAllCatogaries()
        {

            List<CATOGARY_MAST> Details = new List<CATOGARY_MAST>();


            using (entites)
            {
                var query = (from info in entites.CATOGARY_MAST
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }

                return Ok(Details);

            }
        }


        [Route("GetCatogaryByID")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetStudentByUsernamePwd([FromUri]string CATOGARY_ID)
        {

            CATOGARY_MAST Details = new CATOGARY_MAST();


            using (entites)
            {
                var query = (from info in entites.CATOGARY_MAST
                             where info.CATOGARY_ID == CATOGARY_ID
                             select info);
                if (query.Any())
                {
                    Details = query.First();
                }

                return Ok(Details);

            }
        }


        [Route("GetStudentCatogaries")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetStudentCatogaries([FromUri]string StudentID)
        {

           List<STUDENT_DETAILS>  Details = new List<STUDENT_DETAILS>();


            using (entites)
            {
                var query = (from info in entites.STUDENT_DETAILS
                             where info.STUDENT_ID == StudentID
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }

                return Ok(Details);

            }
        }

        [Route("GetCatogariesByStudents")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetCatogariesByStudents([FromUri]string Catagory)
        {

            List<STUDENT_DETAILS> Details = new List<STUDENT_DETAILS>();


            using (entites)
            {
                var query = (from info in entites.STUDENT_DETAILS
                             where info.STUDENT_SKILLS == Catagory
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
