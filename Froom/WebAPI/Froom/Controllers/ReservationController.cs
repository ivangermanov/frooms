using Froom.Data;
using Froom.Data.Models;
using Froom.Data.Repositories;
using Newtonsoft.Json;
using Froom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Froom.Controllers
{
    [RoutePrefix("Api/Reservations")]
    public class ReservationController : ApiController
    {
        [HttpGet]
        [Route("GetReservation")]
        public IHttpActionResult GetReservationForUser(int userId)
        {
            var context = new FroomDbContext();
            var reservarionsRepository = new FroomRepository<Reservation>(context);

            var reservation = reservarionsRepository.GetById(e => e.UserId.Equals(userId), incl => incl.User);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(JsonConvert.SerializeObject(new ReservationInfo { Id = reservation.Id, UserName = reservation.User.Name, RoomName = reservation.RoomName}));
        }

        [HttpPut]
        [Route("MakeReservation")]
        public IHttpActionResult MakeReservationForUser(int userId, string roomName)
        {
            var context = new FroomDbContext();
            var reservarionsRepository = new FroomRepository<Reservation>(context);
            var usersRepository = new FroomRepository<User>(context);

            var user = usersRepository.GetById(e => e.Id.Equals(userId));
            if (user == null)
            {
                return NotFound();
            }
            Reservation r = new Reservation { RoomName = roomName, User = user };
            reservarionsRepository.Add(r);
            return Ok();
        }
    }
}