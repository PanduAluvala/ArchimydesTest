﻿using Archimydes.DataAccessLayer;
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
            using (var entities = new ArchimydesEntities())
            {
                var entity = entities.Stories.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
        }

        // api/UserStory/1
        public HttpResponseMessage Get(int id)
        {
            using (var entities = new ArchimydesEntities())
            {
                var entity = entities.Stories.FirstOrDefault(e => e.UserStoryID == id);
                return entity != null ? Request.CreateResponse(HttpStatusCode.OK, entity) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "story with id " + id.ToString() + "does not exist");
            }
        }

        // api/UserStory
        public HttpResponseMessage Post([FromBody]Story userStory)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
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
