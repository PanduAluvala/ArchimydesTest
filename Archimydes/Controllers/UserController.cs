using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Archimydes.DataAccessLayer;

namespace Archimydes.Controllers
{
    public class UserController : ApiController
    {
        // api/User
        public IEnumerable<User> Get()
        {
            using (var entities = new ArchimydesEntities())
            {
                return entities.Users.ToList();
            }
        }

        // api/User/1
        public User Get(int id)
        {
            using (var entities = new ArchimydesEntities())
            {
                return entities.Users.FirstOrDefault(e => e.UserId == 1);
            }
        }
    }
}
