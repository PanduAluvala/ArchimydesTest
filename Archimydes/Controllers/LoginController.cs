using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Archimydes.BusinessLogic;
using Archimydes.DataAccessLayer;

namespace Archimydes.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ArchimydesEntities _entities;

        public LoginController()
        {
            _entities = new ArchimydesEntities();
        }

        // api/Login
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                var currentUser = _entities.Users.FirstOrDefault(s => s.Email == user.Email);
                if (currentUser == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "The user does not exist");
                }
                var hashPassword = new HashPassword();
                if (currentUser.Password != hashPassword.encrypt(user.Password))
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "The passwords do not match");
                }
                var response = new LoginResponse()
                {
                    UserId = currentUser.UserId,
                    Email = currentUser.Email,
                    Token = currentUser.Token,
                    FirstName = currentUser.Firstname,
                    LastName = currentUser.Lastname,
                    Role = currentUser.Role
                };
                var message = Request.CreateResponse(HttpStatusCode.Created, response);
                message.Headers.Location = new Uri(Request.RequestUri + user.UserId.ToString());
                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
