using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastMinuteTours.Models.Validation
{
    public static class TourValidation
    {
        // Ночи
        public const int MinNights = 1;
        public const int MaxNights = 30;

        // Отдыхающие
        public const int MinVacationers = 1;
        public const int MaxVacationers = 10;

        // Стоимость/доплаты — строки для Range(typeof(decimal), "...", "...")
        public const string MinCostPerVacationerStr = "0,01";
        public const string MaxCostPerVacationerStr = "100000";

        public const string MinSurchargesStr = "0,00";
        public const string MaxSurchargesStr = "100000";
    }
}
