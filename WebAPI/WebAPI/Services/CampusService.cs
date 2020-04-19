using AutoMapper;
using Froom.Data.Dtos;
using Froom.Data.Entities;
using Froom.Data.Models.Campuses;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class CampusService : ICampusService
    {
        private readonly ICampusRepository _campusRepository;
        private readonly IMapper _mapper;

        public CampusService(ICampusRepository campusRepository, IMapper mapper)
        {
            _campusRepository = campusRepository;
            _mapper = mapper;
        }

        public async Task AddCampusAsync(PostCampusModel model)
        {
            var campus = _mapper.Map<Campus>(model);

            await _campusRepository.AddAsync(campus);
        }

        public async Task<IEnumerable<CampusDto>> GetCampuses()
        {
            var campuses = _campusRepository.GetAll();

            return await _mapper.ProjectTo<CampusDto>(campuses).ToListAsync();
        }

        public async Task RemoveCampus(string name)
        {
            var campus = await _campusRepository.GetAsync(name);

            await _campusRepository.RemoveAsync(campus);
        }

        public async Task RemoveCampus(int id)
        {
            var campus = await _campusRepository.GetAsync(id);

            await _campusRepository.RemoveAsync(campus);
        }
    }
}
