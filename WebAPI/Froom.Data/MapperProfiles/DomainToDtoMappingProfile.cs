using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;

namespace Froom.Data.MapperProfiles
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            ConfigureMappings();
        }

        /// <summary>
        /// Creates a mapping between source (Domain) and destination (Dto)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(dto => dto.BuildingCampus, conf => conf.MapFrom(r => r.Building.Campus));
            CreateMap<Reservation, ReservationDto>();
            CreateMap<User, UserDto>();
        }
    }
}
