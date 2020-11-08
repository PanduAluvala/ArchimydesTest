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
        [HttpGet]
        public HttpResponseMessage Get()
        {
            using (var entities = new ArchimydesEntities())
            {
                var entity = entities.Stories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }

        // api/UserStory/id
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            using (var entities = new ArchimydesEntities())
            {
                var entity = entities.Stories.FirstOrDefault(e => e.UserStoryID == id);
                return entity != null ? Request.CreateResponse(HttpStatusCode.OK, entity) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "story with id " + id.ToString() + "does not exist");
            }
        }

        // api/UserStory
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Story userStory)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    userStory.CreatedDateTime = DateTime.Now;
                    userStory.ModifiedDateTime = DateTime.Now;
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

        // api/UserStory/id
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    var entity = entities.Stories.FirstOrDefault(s => s.UserStoryID == id);
                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The story does not exist");
                    }
                    else
                    {
                        entities.Stories.Remove(entity);
                        entities.SaveChanges();
                       return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // api/UserStory/id
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Story story)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    var entity = entities.Stories.FirstOrDefault(s => s.UserStoryID == id);
                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The story does not exist");
                    }
                    else
                    {
                        entity.Summary = story.Summary;
                        entity.Complexity = story.Complexity;
                        entity.Description = story.Description;
                        entity.Type = story.Type;
                        entity.EstimatedTime = story.EstimatedTime;
                        entity.ModifiedDateTime = DateTime.Now;
                        entities.SaveChanges();
                        var message = Request.CreateResponse(HttpStatusCode.Created, entity);
                        message.Headers.Location = new Uri(Request.RequestUri + entity.UserStoryID.ToString());
                        return message;
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
