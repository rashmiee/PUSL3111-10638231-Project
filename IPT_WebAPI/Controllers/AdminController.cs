using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPT_WebAPI.Models;


namespace IPT_WebAPI.Controllers
{
    public class AdminController : ApiController
    {

        IPT_DATABASEEntities1 entites = new IPT_DATABASEEntities1();

        [Route("GetStudentByUsernamePwd")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult GetStudentByUsernamePwd([FromUri]string SU_USERNAME, string SU_PASSWORD)
        {
            SYSTEM_USER Details = new SYSTEM_USER();


            using (entites)
            {
                var query = (from info in entites.SYSTEM_USER
                             where info.SU_USERNAME == SU_USERNAME &&
                             info.SU_PASSWORD == SU_PASSWORD
                             select info);
                if (query.Any())
                {
                    Details = query.First();
                }

                return Ok(Details);

            }
        }
    }
}
