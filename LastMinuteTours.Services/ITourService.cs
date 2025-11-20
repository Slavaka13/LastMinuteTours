using System;
using System.Collections.Generic;
using LastMinuteTours.Entities;

namespace LastMinuteTours.Services
{
    public interface ITourService
    {
        IList<TourModel> GetAllTours();

        void AddTour(TourModel tour);

        void UpdateTour(TourModel tour);

        void DeleteTour(Guid id);

        int GetTotalTours();

        decimal GetTotalCost();

        int GetToursWithSurcharges();

        decimal GetTotalSurcharges();
    }
}
