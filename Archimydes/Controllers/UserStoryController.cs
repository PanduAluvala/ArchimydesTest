using Archimydes.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Archimydes.Controllers
{
    public class UserStoryController : ApiController
    {
        // api/UserStory
        public HttpResponseMessage Get()
        {
            using (ArchimydesEntities entities = new ArchimydesEntities())
            {
                var entity =  entities.Stories.ToList();
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "stories do not exist");
                }
            }
        }

        // api/UserStory/1
        public HttpResponseMessage Get(int id)
        {
            using (ArchimydesEntities entities = new ArchimydesEntities())
            {
                var entity = entities.Stories.FirstOrDefault(e => e.UserStoryID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "story with id " + id.ToString() + "does not exist");
                }
            }
        }

        // api/UserStory
        public HttpResponseMessage Post([FromBody]Story userStory)
        {
            try
            {
                using (ArchimydesEntities entities = new ArchimydesEntities())
                {
                    entities.Stories.Add(userStory);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, userStory);
                    message.Headers.Location = new Uri(Request.RequestUri + userStory.UserStoryID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
