using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;
using LastMinuteTours.Services;
using LastMinuteToursManger.Contracts;
using Microsoft.Extensions.Logging;


namespace LastMinuteToursManager

{
    /// <summary>
    /// Менеджер туров, выступающий промежуточным слоем между пользовательским интерфейсом
    /// Класс инкапсулирует логику работы с турами, перенаправляя операции
    /// в нижележащее хранилище, а также выполняет вычисление агрегированной статистики.
    /// Используется формой и другими компонентами приложения для удобного доступа
    /// </summary>
    public class TourManager:ITourManager
    {

        private readonly ITourService storage;

        private readonly ILogger<TourManager> logger;

        public TourManager(ITourService storage, ILoggerFactory loggerFactory)
        {
            this.storage = storage;
            logger = loggerFactory.CreateLogger<TourManager>();
        }
        public Task<IList<TourModel>> GetAllToursAsync(CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var allget = storage.GetAllToursAsync(cancellationToken);
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "GetAllToursAsync", stopwatch.Elapsed.TotalMilliseconds);
            return allget;
        }

        public Task AddTourAsync(TourModel tour, CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var alladd = storage.AddTourAsync(tour, cancellationToken);
            stopwatch.Stop();
            return alladd;
        }

        public Task UpdateTourAsync(TourModel tour, CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var allupdate = storage.UpdateTourAsync(tour, cancellationToken);
            stopwatch.Stop();
            return allupdate;
        }

        public Task DeleteTourAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var dellllll = storage.DeleteTourAsync(id, cancellationToken);
            stopwatch.Stop();
            return dellllll;
        }

        public async Task<TourStatistics> GetStatisticsAsync(CancellationToken cancellationToken = default)
        {
            var stopwatch = Stopwatch.StartNew();
            var tours = await GetAllToursAsync(cancellationToken);
            var stats = new TourStatistics
                    {
                        TotalTours = tours.Count,
                        TotalCost = tours.Sum(t => t.CostPerVacationer * t.NumberVacationers + t.Surcharges),
                        ToursWithSurcharges = tours.Count(t => t.Surcharges > 0),
                        TotalSurcharges = tours.Sum(t => t.Surcharges)
                    };
            stopwatch.Stop();
            logger.LogInformation("{MethodName} выполнен за {ElapsedMilliseconds}", "GetStatisticsAsync", stopwatch.Elapsed.TotalMilliseconds);

            return stats;

        }

    }
}
