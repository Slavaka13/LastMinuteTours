using System.ComponentModel.DataAnnotations;
using LastMinuteTours.Models.Validation;

namespace LastMinuteTours.Models
{
    /// <summary>Домённая модель туристической поездки (тура).</summary>
    public class TourModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>Направление тура.</summary>
        [Range(1, int.MaxValue, ErrorMessage = "Выберите направление тура")]
        public Direction Direction { get; set; } = Direction.Unknown;

        /// <summary>Дата отправления (вылета/выезда).</summary>
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; } = DateTime.Today;

        /// <summary>Количество ночей проживания.</summary>
        [Range(TourValidation.MinNights, TourValidation.MaxNights,
            ErrorMessage = "Кол-во ночей должно быть от {1} до {2}")]
        public int NumberNights { get; set; } = 1;

        /// <summary>Стоимость на одного отдыхающего, руб.</summary>
        [Range(typeof(decimal), TourValidation.MinCostPerVacationerStr, TourValidation.MaxCostPerVacationerStr,
            ErrorMessage = "Стоимость должна быть от {1} до {2}")]
        public decimal CostPerVacationer { get; set; } = 0.00m;

        /// <summary>Число отдыхающих.</summary>
        [Range(TourValidation.MinVacationers, TourValidation.MaxVacationers,
            ErrorMessage = "Кол-во отдыхающих должно быть от {1} до {2}")]
        public int NumberVacationers { get; set; } = 1;

        /// <summary>Наличие Wi-Fi.</summary>
        public bool AvailabilityWiFi { get; set; } = false;

        /// <summary>Сумма доплат, руб.</summary>
        [Range(typeof(decimal), TourValidation.MinSurchargesStr, TourValidation.MaxSurchargesStr,
            ErrorMessage = "Доплаты должны быть от {1} до {2}")]
        public decimal Surcharges { get; set; } = 0.00m;

        /// <summary>Итоговая стоимость тура</summary>
        public decimal TotalCost => (CostPerVacationer * NumberVacationers) + Surcharges;

        /// <summary>Поверхностный клон (осторожно с ссылочными полями).</summary>
        public TourModel Clone() => (TourModel)this.MemberwiseClone();
    }
}
