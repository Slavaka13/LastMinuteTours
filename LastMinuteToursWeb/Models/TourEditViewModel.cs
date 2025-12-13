using System;
using System.ComponentModel.DataAnnotations;
using LastMinuteTours.Entities;

namespace LastMinuteToursWeb.Models
{
    /// <summary>
    /// Модель представления для добавления и редактирования тура.
    /// Используется в формах Create и Edit.
    /// </summary>
    public class TourEditViewModel
    {
        /// <summary>
        /// Уникальный идентификатор тура.
        /// Используется при редактировании существующей записи.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Направление тура.
        /// Обязательное поле, выбираемое из перечисления Direction.
        /// </summary>
        [Required(ErrorMessage = "Выберите направление")]
        public Direction? Direction { get; set; }

        /// <summary>
        /// Дата вылета тура.
        /// По умолчанию устанавливается текущая дата.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } = DateTime.Today;

        /// <summary>
        /// Количество ночей пребывания.
        /// Допустимый диапазон значений — от 1 до 365.
        /// </summary>
        [Range(1, 365)]
        public int NumberNights { get; set; }

        /// <summary>
        /// Стоимость тура на одного отдыхающего.
        /// Значение должно быть положительным.
        /// </summary>
        [Range(0.01, double.MaxValue)]
        public decimal CostPerVacationer { get; set; }

        /// <summary>
        /// Количество отдыхающих в туре.
        /// Допустимый диапазон значений — от 1 до 100.
        /// </summary>
        [Range(1, 100)]
        public int NumberVacationers { get; set; }

        /// <summary>
        /// Признак наличия Wi-Fi в туре.
        /// </summary>
        public bool AvailabilityWiFi { get; set; }

        /// <summary>
        /// Дополнительные доплаты по туру.
        /// Значение не может быть отрицательным.
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal Surcharges { get; set; }
    }
}
