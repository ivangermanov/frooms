using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IFloorService"/>
    public class FloorService: IFloorService
    {
        private readonly IFloorRepository _floorRepository;
        private readonly IMapper _mapper;

        public FloorService(IFloorRepository floorRepository, IMapper mapper)
        {
            _floorRepository = floorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FloorDto>> GetFloors(string buildingName)
        {
            var floors = _floorRepository.GetForBuildingAsync(buildingName);

            return await _mapper.ProjectTo<FloorDto>(floors).ToListAsync();
        }
    }
}
