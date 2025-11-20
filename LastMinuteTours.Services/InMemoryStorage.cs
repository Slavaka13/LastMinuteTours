using System;
using System.Collections.Generic;
using System.Linq;
using LastMinuteTours.Entities;

namespace LastMinuteTours.Services
{
    public class InMemoryStorage : ITourService
    {
        // Хранилище всех туров в памяти
        private readonly List<TourModel> tours = new();

        // Возвращаем список всех туров
        public IList<TourModel> GetAllTours()
        {
            return tours;
        }

        // Добавляем новый тур
        public void AddTour(TourModel tour)
        {
            if (tour == null) throw new ArgumentNullException(nameof(tour));
            tours.Add(tour);
        }

        // Обновляем существующий тур
        public void UpdateTour(TourModel tour)
        {
            if (tour == null) throw new ArgumentNullException(nameof(tour));

            var existing = tours.FirstOrDefault(t => t.Id == tour.Id);
            if (existing == null)
                return;

            existing.Direction = tour.Direction;
            existing.DepartureDate = tour.DepartureDate;
            existing.NumberNights = tour.NumberNights;
            existing.CostPerVacationer = tour.CostPerVacationer;
            existing.NumberVacationers = tour.NumberVacationers;
            existing.AvailabilityWiFi = tour.AvailabilityWiFi;
            existing.Surcharges = tour.Surcharges;
        }

        // Удаляем тур по Id
        public void DeleteTour(Guid id)
        {
            var existing = tours.FirstOrDefault(t => t.Id == id);
            if (existing != null)
                tours.Remove(existing);
        }

        // Статистика
        public int GetTotalTours() => tours.Count;

        public decimal GetTotalCost()
        {
            return tours.Sum(t => t.CostPerVacationer * t.NumberVacationers + t.Surcharges);
        }

        public int GetToursWithSurcharges()
        {
            return tours.Count(t => t.Surcharges > 0);
        }

        public decimal GetTotalSurcharges()
        {
            return tours.Sum(t => t.Surcharges);
        }
    }
}
