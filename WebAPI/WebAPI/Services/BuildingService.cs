using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Buildings;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    /// <inheritdoc cref="IBuildingService"/>
    public class BuildingService : IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;

        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }

        public async Task AddBuildingAsync(PostBuildingModel model)
        {
            var building = _mapper.Map<Building>(model);

            await _buildingRepository.AddAsync(building);
        }

        public async Task<IEnumerable<BuildingDto>> GetBuildings(string? campusName)
        {
            var buildings = _buildingRepository.GetAll()
                .Where(b => string.IsNullOrEmpty(campusName) || b.Campus.Name.Equals(campusName));

            return await _mapper.ProjectTo<BuildingDto>(buildings).ToListAsync();
        }

        public async Task RemoveBuilding(int id)
        {
            var building = await _buildingRepository.GetByIdAsync(id);

            await _buildingRepository.RemoveAsync(building);
        }
    }
}
