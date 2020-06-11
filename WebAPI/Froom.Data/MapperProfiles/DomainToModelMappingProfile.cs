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
            CreateMap<PostRoomModel, Room>().ForMember(
                r => r.DetailsId,
                conf => conf.MapFrom<CustomRoomDetailsResolver>());

            CreateMap<DeleteRoomModel, Room>().ForMember(
                r => r.DetailsId,
                conf => conf.MapFrom<CustomRoomDetailsResolver>());

            CreateMap<PostReservationModel, Reservation>();
            CreateMap<PostUserModel, User>();
            CreateMap<AdminUpdateReservationModel, Reservation>();
            CreateMap<PostCampusModel, Campus>();
            CreateMap<PostBuildingModel, Building>();
        }
    }

    public class CustomRoomDetailsResolver : IValueResolver<PostRoomModel, Room, int>, IValueResolver<DeleteRoomModel, Room, int>
    {
        public int Resolve(PostRoomModel source, Room destination, int destMember, ResolutionContext context)
        {
            dynamic detailsDic = context.Options.Items["DetailsId"];

            return (detailsDic.Result)[source];
        }

        public int Resolve(DeleteRoomModel source, Room destination, int destMember, ResolutionContext context)
        {
            dynamic detailsDic = context.Options.Items["DetailsId"];

            return (detailsDic.Result)[source];
        }
    }
}
