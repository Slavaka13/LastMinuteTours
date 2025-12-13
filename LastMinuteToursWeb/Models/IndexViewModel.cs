using LastMinuteTours.Entities;
using LastMinuteToursManger.Contracts;

namespace LastMinuteToursWeb.Models
{
    /// <summary>
    /// Модель представления главной страницы.
    /// Содержит список туров и агрегированную статистику по ним.
    /// </summary>
    public class TourIndexViewModel
    {
        /// <summary>
        /// Коллекция всех туров, отображаемых в таблице на главной странице.
        /// </summary>
        public IEnumerable<TourModel> Tours { get; set; } = Enumerable.Empty<TourModel>();

        /// <summary>
        /// Агрегированная статистика по турам
        /// (общее количество, суммарная стоимость и доплаты).
        /// </summary>
        public TourStatistics Statistics { get; set; } = new();
    }
}
