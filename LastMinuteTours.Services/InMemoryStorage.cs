using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;
using LastMinuteTours.Services.Contracts;
using Microsoft.Extensions.Logging;

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

        private readonly ILogger<InMemoryStorage> logger;

        public InMemoryStorage(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<InMemoryStorage>();
        }

        /// <inheritdoc />
        public Task<IList<TourModel>> GetAllToursAsync(CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

            IList<TourModel> result;
            lock (syncRoot)
            {
                result = tours.ToList();
            }
    
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "GetAllToursAsync", stopwatch.Elapsed.TotalMilliseconds);

            return Task.FromResult(result);
        }

        /// <inheritdoc />
        public Task AddTourAsync(TourModel tour, CancellationToken token)
        {
           
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));
            var stopwatch = Stopwatch.StartNew();

            lock (syncRoot)
            {
                tours.Add(tour);
            }
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "AddTourAsync", stopwatch.Elapsed.TotalMilliseconds);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UpdateTourAsync(TourModel tour, CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

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
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "UpdateTourAsync", stopwatch.Elapsed.TotalMilliseconds);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task DeleteTourAsync(Guid id, CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

            lock (syncRoot)
            {
                var existing = tours.FirstOrDefault(t => t.Id == id);
                if (existing != null)
                    tours.Remove(existing);
            }
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "DeleteTourAsync", stopwatch.Elapsed.TotalMilliseconds);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<TourStatistics> GetStatisticsAsync(CancellationToken token)
        {
            var stopwatch = Stopwatch.StartNew();

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
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "GetStatisticsAsync", stopwatch.Elapsed.TotalMilliseconds);

            return Task.FromResult(stats);
        }
    }
}
