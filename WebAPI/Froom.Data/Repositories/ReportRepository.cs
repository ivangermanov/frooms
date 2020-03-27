using System;
using System.Linq;
using System.Threading.Tasks;
using Froom.Data.Database;
using Froom.Data.Entities;
using Froom.Data.Exceptions;
using Froom.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Froom.Data.Repositories
{
    /// <inheritdoc cref="IReportRepository"/>
    class ReportRepository : IReportRepository
    {
        private readonly FroomContext _context;
        private readonly DbSet<Report> _reports;

        public ReportRepository(FroomContext context)
        {
            _context = context ?? throw new ArgumentException($"{nameof(FroomContext)} is null.");
            _reports = _context.Set<Report>();
        }

        public async Task AddAsync(Report report)
        {
            await _reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Report> GetAll()
        {
            return _reports
                .Include(r => r.User)
                .Include(r => r.Room);
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await _reports
                .Include(r => r.User)
                .Include(r => r.Room)
                .Include(r => r.Pictures)
                .SingleOrDefaultAsync(r => r.Id == id) ??
                throw new DoesNotExistException($"Report with ID: {id} does not exist.");
        }

        public async Task RemoveAsync(Report report)
        {
            _reports.Remove(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Report report)
        {
            _reports.Update(report);
            await _context.SaveChangesAsync();
        }
    }
}
