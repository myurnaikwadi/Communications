using KindleSpur.Data;
using KindleSpur.Models;
using KindleSpur.Models.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KindleSpur.Services.Controllers
{
    public class AppUserController : ApiController
    {
        IUserRepository _userRepo;
        public AppUserController()
        {
            _userRepo = new UserRepository();
        }
        // GET: api/AppUser
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AppUser/5
        public string Get(int id)
        {
            return "value";
        }

        [System.Web.Http.HttpPost]
        // POST: api/AppUser
        public void Post(User user)            
        {
            _userRepo.AddNewUser(user);
        }

        // PUT: api/AppUser/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AppUser/5
        public void Delete(int id)
        {
        }
    }
}
