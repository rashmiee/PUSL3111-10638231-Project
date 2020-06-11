using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPT_WebAPI.Models;
namespace IPT_WebAPI.Controllers
{
    public class CommunicationController : ApiController
    {
        IPT_DATABASEEntities1 entites = new IPT_DATABASEEntities1();


        [Route("NewMessageFromStd")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult NewMessageFromStd([FromUri]string STUDENT_ID, string IT_EXPERT_USERNAME, string MESSAGE_BODY_STD)
        {
            MESSAGE_MASTER Details = new MESSAGE_MASTER();

            using (entites)
            {
                var query = (from info in entites.MESSAGE_MASTER
                             select info);

                Details.STUDENT_ID = STUDENT_ID;
                Details.IT_EXPERT_USERNAME = IT_EXPERT_USERNAME;
                Details.MESSAGE_BODY_STD = MESSAGE_BODY_STD;
;
                entites.MESSAGE_MASTER.Add(Details);
                entites.SaveChanges();

                return Ok(true);

            }
        }


        [Route("NewMessageFromIte")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult NewMessageFromIte([FromUri]string STUDENT_ID, string IT_EXPERT_USERNAME, string MESSAGE_BODY_ITE)
        {
            MESSAGE_MASTER Details = new MESSAGE_MASTER();

            using (entites)
            {
                var query = (from info in entites.MESSAGE_MASTER
                             select info);

                Details.STUDENT_ID = STUDENT_ID;
                Details.IT_EXPERT_USERNAME = IT_EXPERT_USERNAME;
                Details.MESSAGE_BODY_ITE = MESSAGE_BODY_ITE;
                
                entites.MESSAGE_MASTER.Add(Details);
                entites.SaveChanges();

                return Ok(true);

            }
        }

        [Route("ViewMessagesOfSTD")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult NewMessageFromIte([FromUri]string STUDENT_ID)
        {

            List<MESSAGE_MASTER> Details = new List<MESSAGE_MASTER>();

            using (entites)
            {
                var query = (from info in entites.MESSAGE_MASTER
                             where info.STUDENT_ID == STUDENT_ID
                             select info);

                if (query.Any())
                {
                    Details = query.ToList();
                }

                return Ok(Details);

            }
        }


        [Route("ViewMessagesOfITE")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult ViewMessagesOfITE([FromUri]string IT_EXPERT_USERNAME)
        {

            List<MESSAGE_MASTER> Details = new List<MESSAGE_MASTER>();

            using (entites)
            {
                var query = (from info in entites.MESSAGE_MASTER
                             where info.IT_EXPERT_USERNAME == IT_EXPERT_USERNAME
                             select info);

                if (query.Any())
                {
                    Details = query.ToList();
                }

                return Ok(Details);

            }
        }


        [Route("ViewMessagesSTD_ITE")]
        [AcceptVerbs("POST", "GET")]
        public IHttpActionResult ViewMessagesSTD_ITE([FromUri]string IT_EXPERT_USERNAME, string STUDENT_ID)
        {

            List<MESSAGE_MASTER> Details = new List<MESSAGE_MASTER>();

            using (entites)
            {
                var query = (from info in entites.MESSAGE_MASTER
                             where info.IT_EXPERT_USERNAME == IT_EXPERT_USERNAME &&
                             info.STUDENT_ID == STUDENT_ID 
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
