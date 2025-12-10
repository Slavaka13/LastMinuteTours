using LastMinuteTours.Entities;
using LastMinuteTours.Services;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using System.Threading;


namespace DataBaseStorage
{
    /// <summary>
    /// Реализация ITourService с использованием базы данных через Entity Framework Core.
    /// </summary>
    public class DataBaseStorage : ITourService
    {
        public async Task AddTourAsync(TourModel tour, CancellationToken token)
        {
            using var database = new DataBaseContext();
            database.TourModel.Add(tour);
            await database.SaveChangesAsync(token);
        }

        public async Task DeleteTourAsync(Guid id, CancellationToken token)
        {
            using var database = new DataBaseContext();
            var tour = await database.TourModel
                .FirstOrDefaultAsync(t => t.Id == id, token);

            if (tour != null)
            {
                database.TourModel.Remove(tour);
                await database.SaveChangesAsync(token);
            }
        }

        public async Task<IList<TourModel>> GetAllToursAsync(CancellationToken token)
        {
            using var database = new DataBaseContext();
            var tour = await database.TourModel.AsNoTracking().ToListAsync(token);
            return tour;
        }

        public async Task UpdateTourAsync(TourModel tour, CancellationToken token)
        {
            using var database = new DataBaseContext();
            database.TourModel.Update(tour);
            await database.SaveChangesAsync(token);
        }
    }
}

