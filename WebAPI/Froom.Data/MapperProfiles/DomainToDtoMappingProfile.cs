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
        ///     Creates a mapping between source (Domain) and destination (Dto)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<Room, RoomDto>()
                .ForMember(
                    dto => dto.CampusName,
                    conf => conf.MapFrom(r => r.Details.Building.CampusName))
                .ForMember(
                    dto => dto.BuildingName,
                    conf => conf.MapFrom(r => r.Details.BuildingName))
                .ForMember(
                    dto => dto.FloorNumber,
                    conf => conf.MapFrom(r => r.Details.FloorNumber));

            CreateMap<Room, FloorMapRoomDTO>()
                .ForMember(dto => dto.CampusName, conf => conf.MapFrom(r => r.Details.Building.CampusName))
                .ForMember(
                    dto => dto.BuildingName,
                    conf => conf.MapFrom(r => r.Details.BuildingName))
                .ForMember(
                    dto => dto.FloorNumber,
                    conf => conf.MapFrom(r => r.Details.FloorNumber));

            CreateMap<BuildingContents, BuildingContentsDto>()
                .ForMember(
                    dto => dto.FloorOrder,
                    conf => conf.MapFrom(f => f.Floor.Order));

            CreateMap<Notification, NotificationDto>()
                .ForMember(
                    dto => dto.CreatedDate,
                    conf => conf.MapFrom(n => n.CreatedDate.ToString("MM/dd/yy")));

            CreateMap<Reservation, ReservationDto>();
            CreateMap<User, UserDto>();
            CreateMap<Campus, CampusDto>();
            CreateMap<Building, BuildingDto>();
            CreateMap<Floor, FloorDto>();
        }
    }
}