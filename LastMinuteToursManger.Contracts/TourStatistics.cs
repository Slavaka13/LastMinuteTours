namespace LastMinuteToursManger.Contracts
{
    /// <summary>
    /// Сводная статистика по турам.
    /// </summary>
    public class TourStatistics
    {
        /// <summary>
        /// Общее количество туров.
        /// </summary>
        public int TotalTours { get; set; }

        /// <summary>
        /// Суммарная стоимость всех туров.
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Количество туров с доплатами.
        /// </summary>
        public int ToursWithSurcharges { get; set; }

        /// <summary>
        /// Суммарный размер всех доплат.
        /// </summary>
        public decimal TotalSurcharges { get; set; }
    }
}
