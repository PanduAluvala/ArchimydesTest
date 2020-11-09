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
        // Get all stories for admin
        // Get all stories of user based on token
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    var jwtAuthorizationParameter = Request.Headers.Authorization.Parameter;
                    var currentLoggedInUser =
                        entities.Users.FirstOrDefault(user => user.Token == jwtAuthorizationParameter);
                    if (currentLoggedInUser == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not Authorized");
                    }
                    if (currentLoggedInUser.Role.ToLower() == "user")
                    {
                        var userEntities = entities.Stories.Where(e => e.UserId ==currentLoggedInUser.UserId).Select(story =>
                            new
                            {
                                UserStoryID = story.UserStoryID,
                                UserId = story.UserId,
                                Summary = story.Summary,
                                Description = story.Description,
                                Type = story.Type,
                                Complexity = story.Complexity,
                                EstimatedDateTime = story.EstimatedTime
                            }).ToList();

                        return Request.CreateResponse(HttpStatusCode.OK, userEntities);
                    }
                    var entity = entities.Stories.Select(story =>
                        new
                        {
                            UserStoryID = story.UserStoryID,
                            UserId = story.UserId,
                            Summary = story.Summary,
                            Status = story.Status,
                            Description = story.Description,
                            Type = story.Type,
                            Complexity = story.Complexity,
                            EstimatedDateTime = story.EstimatedTime
                        }).ToList();
                    return currentLoggedInUser.Role.ToLower() == "admin" ? Request.CreateResponse(HttpStatusCode.OK, entity) : Request.CreateResponse(HttpStatusCode.NotFound, "User does not exist");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // api/UserStory/id
        // Get the stories created by user with userid
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    var jwtAuthorizationParameter = Request.Headers.Authorization.Parameter;
                    var currentLoggedInUser =
                        entities.Users.FirstOrDefault(user => user.Token == jwtAuthorizationParameter);
                    if (currentLoggedInUser == null || currentLoggedInUser.Role.ToLower() != "user" || currentLoggedInUser.UserId != id)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not Authorized");
                    }
                    var entity = entities.Stories.Where(e => e.UserId == id).Select(story =>
                        new
                        {
                            UserStoryID = story.UserStoryID, UserId = story.UserId, Summary = story.Summary,
                            Description = story.Description, Type = story.Type, Complexity = story.Complexity,
                            EstimatedDateTime = story.EstimatedTime
                        }).ToList();
                    return entity.Count > 0 ? Request.CreateResponse(HttpStatusCode.OK, entity) : Request.CreateErrorResponse(HttpStatusCode.NotFound, "stories do not exist for this user");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // api/UserStory
        //create story for user
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Story userStory)
        {
            try
            {
                var jwtAuthorizationParameter = Request.Headers.Authorization.Parameter;
                using (var entities = new ArchimydesEntities())
                {
                    var currentLoggedInUser =
                        entities.Users.FirstOrDefault(user => user.Token == jwtAuthorizationParameter);
                    if (currentLoggedInUser == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not Authorized");
                    }
                    userStory.CreatedDateTime = DateTime.Now;
                    userStory.ModifiedDateTime = DateTime.Now;
                    userStory.UserId = currentLoggedInUser.UserId;
                    entities.Stories.Add(userStory);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, "User story created");
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
        // edit story for admin
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Story story)
        {
            try
            {
                using (var entities = new ArchimydesEntities())
                {
                    var jwtAuthorizationParameter = Request.Headers.Authorization.Parameter;
                    var currentLoggedInUser =
                        entities.Users.FirstOrDefault(user => user.Token == jwtAuthorizationParameter);
                    if (currentLoggedInUser == null || currentLoggedInUser.Role.ToLower() != "admin")
                    {
                        return Request.CreateResponse(HttpStatusCode.Unauthorized, "User not Authorized");
                    }
                    var entity = entities.Stories.FirstOrDefault(s => s.UserStoryID == id);
                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "The story does not exist");
                    }
                    entity.Summary = story.Summary;
                    entity.Complexity = story.Complexity;
                    entity.Description = story.Description;
                    entity.Status = story.Status;
                    entity.Type = story.Type;
                    entity.EstimatedTime = story.EstimatedTime;
                    entity.ModifiedDateTime = DateTime.Now;
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, entity);
                    message.Headers.Location = new Uri(Request.RequestUri + entity.UserStoryID.ToString());
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
