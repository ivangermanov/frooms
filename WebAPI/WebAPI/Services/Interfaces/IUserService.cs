using Froom.Data.Models.Users;
using System.Threading.Tasks;

namespace WebAPI.Services.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Adds a user.
        /// </summary>
        public Task AddUserAsync(PostUserModel model);
    }
}
