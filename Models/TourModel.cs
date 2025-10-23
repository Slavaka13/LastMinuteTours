using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LastMinuteTours.Models
{
    /// <summary>
    /// Домённая модель туристической поездки (тура).
    /// </summary>
    public class TourModel
    {
        /// <summary>
        /// Уникальный идентификатор тура.
        /// </summary>
        public Guid Id { get; set; }

        /// <inheritdoc cref="Models.Direction"/>
        [Required(ErrorMessage = "Выберите направление тура")]
        public Direction Direction { get; set; }

        /// <summary>
        /// Дата отправления (вылета/выезда).
        /// </summary>
        public DateOnly DepartureDate { get; set; }

        /// <summary>
        /// Количество ночей проживания.
        /// </summary>
        [Range(1, 30, ErrorMessage = "Кол-во ночей должно быть от 1 до 30")]
        public int NumberNights { get; set; }

        /// <summary>
        /// Стоимость на одного отдыхающего, руб.
        /// </summary>
        [Range(0.01, 100000, ErrorMessage = "Стоимость должна быть в диапазоне от 0 до 100000")]
        public decimal CostPerVacationer { get; set; }

        /// <summary>
        /// Число отдыхающих.
        /// </summary>
        [Range(1, 10, ErrorMessage = "Кол-во отдыхающих должно быть от 1 до 10")]
        public int NumberVacationers { get; set; }

        /// <summary>
        /// Наличие Wi-Fi в туре/размещении.
        /// </summary>
        public bool AvailabilityWiFi { get; set; }

        /// <summary>
        /// Сумма доплат, руб. (топливные сборы, страховки и пр.).
        /// </summary>
        [Range(0.00, 100000, ErrorMessage = "Доплаты должны быть в диапазоне от 0 до 100000")]
        public decimal Surcharges { get; set; }

        /// <summary>
        /// Итоговая стоимость тура: (цена за человека × количество) + доплаты.
        /// </summary>
        public decimal TotalCost => (CostPerVacationer * NumberVacationers) + Surcharges;
    }
}
