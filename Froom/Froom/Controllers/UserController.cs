using Froom.Data;
using Froom.Data.Models;
using Froom.Data.Repositories;
using Froom.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Froom.Controllers
{
    [RoutePrefix("Api/Users")]
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            var context = new FroomDbContext();
            var usersRepository = new FroomRepository<User>(context);

            var users = usersRepository.GetAll().ToList();
            List<UserInfo> response = new List<UserInfo>();

            foreach(User u in users)
            {
                response.Add(new UserInfo { Id = u.Id, Name = u.Name, Number = u.Number, Role = u.Role });
            }

            return Ok(JsonConvert.SerializeObject(response));
        }

        [HttpGet]
        [Route("GetUser")]
        public IHttpActionResult GetUser(int id)
        {
            var context = new FroomDbContext();
            var usersRepository = new FroomRepository<User>(context);

            var user = usersRepository.GetById(e => e.Id.Equals(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(new UserInfo { Id = user.Id, Name = user.Name, Number = user.Number, Role = user.Role }));
        }
    }
}
