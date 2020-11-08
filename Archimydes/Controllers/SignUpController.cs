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
    public class SignUpController : ApiController
    {
        private readonly ArchimydesEntities _entities;
        private readonly JwtTokenGenerator _tokenGenerator;

        public SignUpController()
        {
            _entities = new ArchimydesEntities();
            _tokenGenerator = new JwtTokenGenerator();
        }

        // api/SignUp
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            try
            {
                var userExists = _entities.Users.Any(e => e.Email == user.Email);
                if (userExists)
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, "User already exists");
                }
                if (!BusinessLoginHelper.IsValidEmail(user.Email))
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, "Email address not valid");
                }
                user.CreatedDateTime = DateTime.Now;
                user.ModifiedDateTime = DateTime.Now;
                user.Password = new HashPassword().encrypt(user.Password);
                var jwtToken = _tokenGenerator.GenerateToken(user.Email, user.Password);
                user.Token = jwtToken;
                _entities.Users.Add(user);
                _entities.SaveChanges();
                var message = Request.CreateResponse(HttpStatusCode.Created, "User successfully created");
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
