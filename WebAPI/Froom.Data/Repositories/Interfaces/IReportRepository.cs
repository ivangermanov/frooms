using Froom.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Froom.Data.Repositories.Interfaces
{
    public interface IReportRepository
    {
        /// <summary>
        /// Adds a report to the database context.
        /// </summary>
        /// <param name="report"> The report to be added.</param>
        Task AddAsync(Report report);

        /// <summary>
        /// Gets all reservations from the database context.
        /// </summary>
        IQueryable<Report> GetAll();

        /// <summary>
        /// Gets a report by id from the database context.
        /// </summary>
        /// <param name="id"> The id of the report.</param>
        Task<Report> GetByIdAsync(int id);

        /// <summary>
        /// Updates information about a report.
        /// </summary>
        /// <param name="report"> The report to be updated.</param>
        Task UpdateAsync(Report report);

        /// <summary>
        /// Updates information about a report.
        /// </summary>
        /// <param name="report"> The report to be updated.</param>
        Task RemoveAsync(Report report);
    }
}
