using AutoMapper;
using Froom.Data.Entities;
using Froom.Data.Models.Buildings;
using Froom.Data.Models.Campuses;
using Froom.Data.Models.Reservations;
using Froom.Data.Models.Rooms;
using Froom.Data.Models.Users;

namespace Froom.Data.MapperProfiles
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            ConfigureMappings();
        }

        /// <summary>
        /// Creates a mapping between source (Domain) and destination (Model)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<PostRoomModel, Room>();
            CreateMap<PostReservationModel, Reservation>();
            CreateMap<PostUserModel, User>();
            CreateMap<PostCampusModel, Campus>();
            CreateMap<PostBuildingModel, Building>();
        }
    }
}
