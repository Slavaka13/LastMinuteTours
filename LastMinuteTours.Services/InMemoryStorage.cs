using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;
using LastMinuteTours.Services.Contracts;

namespace LastMinuteTours.Services
{
    /// <summary>
    /// Простая реализация ITourService в памяти процесса.
    /// Подходит для тестов, примеров и демонстраций.
    /// </summary>
    public class InMemoryStorage : ITourService
    {
        private readonly List<TourModel> tours = new();
        private readonly object syncRoot = new();

        /// <inheritdoc />
        public Task<IList<TourModel>> GetAllToursAsync(CancellationToken token)
        {
            lock (syncRoot)
            {
                return Task.FromResult<IList<TourModel>>(tours.ToList());
            }
        }

        /// <inheritdoc />
        public Task AddTourAsync(TourModel tour, CancellationToken token)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

            lock (syncRoot)
            {
                tours.Add(tour);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UpdateTourAsync(TourModel tour, CancellationToken token)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

            lock (syncRoot)
            {
                var existing = tours.FirstOrDefault(t => t.Id == tour.Id);

                if (existing != null)
                {
                    existing.Direction = tour.Direction;
                    existing.DepartureDate = tour.DepartureDate;
                    existing.NumberNights = tour.NumberNights;
                    existing.CostPerVacationer = tour.CostPerVacationer;
                    existing.NumberVacationers = tour.NumberVacationers;
                    existing.AvailabilityWiFi = tour.AvailabilityWiFi;
                    existing.Surcharges = tour.Surcharges;
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task DeleteTourAsync(Guid id, CancellationToken token)
        {
            lock (syncRoot)
            {
                var existing = tours.FirstOrDefault(t => t.Id == id);
                if (existing != null)
                    tours.Remove(existing);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<TourStatistics> GetStatisticsAsync(CancellationToken token)
        {
            TourStatistics stats;

            lock (syncRoot)
            {
                stats = new TourStatistics
                {
                    TotalTours = tours.Count,
                    TotalCost = tours.Sum(t => t.CostPerVacationer * t.NumberVacationers + t.Surcharges),
                    ToursWithSurcharges = tours.Count(t => t.Surcharges > 0),
                    TotalSurcharges = tours.Sum(t => t.Surcharges)
                };
            }

            return Task.FromResult(stats);
        }
    }
}
