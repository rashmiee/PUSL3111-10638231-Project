using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPT_WebAPI.Models;

namespace IPT_WebAPI.Controllers
{
    public class It_ExpertController : ApiController
    {
        IPT_DATABASEEntities1 entites = new IPT_DATABASEEntities1();

        [Route("RegisterNewItExpert")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult RegisterNewItExpert([FromUri]string IT_EXPERT_USERNAME, string IT_EXPERT_PASSWORD, string IT_EXPERT_EMAIL, string IT_EXPERT_COMPANY, string IT_EXPERT_EXPERT_AREA, string IT_EXPERT_PROF_PIC_URL, string IT_EXPERT_USER_TYPE)
        {
            using (entites)
            {
                var query = (from info in entites.IT_EXPERT_MAST

                             select info);

                IT_EXPERT_MAST Details = new IT_EXPERT_MAST();

                Details.IT_EXPERT_USERNAME = IT_EXPERT_USERNAME;
                Details.IT_EXPERT_PASSWORD = IT_EXPERT_PASSWORD;
                Details.IT_EXPERT_EMAIL = IT_EXPERT_EMAIL;
                Details.IT_EXPERT_COMPANY = IT_EXPERT_COMPANY;
                Details.IT_EXPERT_EXPERT_AREA = IT_EXPERT_EXPERT_AREA;
                Details.IS_APPROVED = 1;
                Details.USER_TYPE = "ITE";
                entites.IT_EXPERT_MAST.Add(Details);
                entites.SaveChanges();

                return Ok(true);

            }
        }
        [Route("ApproveItExpert")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult ApproveItExpert([FromUri]string IT_EXPERT_USERNAME, string APPROVED_USER, DateTime IS_APPROVED_DATE)
        {
            IT_EXPERT_MAST Details = new IT_EXPERT_MAST();

            using (entites)
            {
                var query = (from info in entites.IT_EXPERT_MAST
                             where info.IT_EXPERT_USERNAME == IT_EXPERT_USERNAME
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

        [Route("GetApprovedItExperts")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetApprovedItExperts()
        {
            List<IT_EXPERT_MAST> Details = new List<IT_EXPERT_MAST>();


            using (entites)
            {
                var query = (from info in entites.IT_EXPERT_MAST
                             where info.IS_APPROVED == 1
                             select info);
                if (query.Any())
                {
                    Details = query.ToList();
                }


                return Ok(Details);

            }
        }
        [Route("GetItExpertByUsernamePwd")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetItExpertByUsernamePwd([FromUri]string IT_EXPERT_USERNAME, string IT_EXPERT_PASSWORD)
        {
            IT_EXPERT_MAST Details = new IT_EXPERT_MAST();


            using (entites)
            {
                var query = (from info in entites.IT_EXPERT_MAST
                             where info.IS_APPROVED == 1 &&
                             info.IT_EXPERT_USERNAME == IT_EXPERT_USERNAME &&
                             info.IT_EXPERT_PASSWORD == IT_EXPERT_PASSWORD
                             select info);
                if (query.Any())
                {
                    Details = query.First();
                }

                return Ok(Details);

            }
        }
        [Route("GetAllItExperts")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetAllItExperts()
        {
            List<IT_EXPERT_MAST> Details = new List<IT_EXPERT_MAST>();


            using (entites)
            {
                var query = (from info in entites.IT_EXPERT_MAST
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