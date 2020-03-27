using Froom.Data.Dtos.Rooms;
using Froom.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IRoomService
    {
        public Task AddAsync(PostRoomModel model);

        public IQueryable<RoomDto> Rooms();
    }
}