using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LastMinuteTours.Entities;
using LastMinuteTours.Services;

namespace LastMinuteTours.Services
{
    public class InMemoryStorage : ITourService
    {
        private readonly List<TourModel> tours = new();

        public Task<IList<TourModel>> GetAllToursAsync(CancellationToken token)
        {
            return Task.FromResult<IList<TourModel>>(tours);
        }

        public Task AddTourAsync(TourModel tour, CancellationToken token)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

            tours.Add(tour);
            return Task.CompletedTask;
        }

        public Task UpdateTourAsync(TourModel tour, CancellationToken token)
        {
            if (tour == null)
                throw new ArgumentNullException(nameof(tour));

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

            return Task.CompletedTask;
        }

        public Task DeleteTourAsync(Guid id, CancellationToken token)
        {
            var existing = tours.FirstOrDefault(t => t.Id == id);
            if (existing != null)
                tours.Remove(existing);

            return Task.CompletedTask;
        }

        public Task<int> GetTotalToursAsync(CancellationToken token)
        {
            return Task.FromResult(tours.Count);
        }

        public Task<decimal> GetTotalCostAsync(CancellationToken token)
        {
            decimal sum = tours.Sum(t => t.CostPerVacationer * t.NumberVacationers + t.Surcharges);
            return Task.FromResult(sum);
        }

        public Task<int> GetToursWithSurchargesAsync(CancellationToken token)
        {
            return Task.FromResult(tours.Count(t => t.Surcharges > 0));
        }

        public Task<decimal> GetTotalSurchargesAsync(CancellationToken token)
        {
            return Task.FromResult(tours.Sum(t => t.Surcharges));
        }
    }
}
