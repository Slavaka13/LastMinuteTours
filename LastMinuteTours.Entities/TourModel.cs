namespace LastMinuteTours.Entities
{
    /// <summary>
    /// Модель тура, содержащая основные сведения о направлении,
    /// датах, стоимости и дополнительных услугах.
    /// </summary>
    public class TourModel
    {
        /// <summary>
        /// Уникальный идентификатор тура.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Направление тура (страна или место назначения).
        /// </summary>
        public Direction Direction { get; set; }


        /// <summary>
        /// Дата выезда туристов.
        /// </summary>
        public DateTime DepartureDate { get; set; }


        /// <summary>
        /// Количество ночей, включённых в тур.
        /// </summary>
        public int NumberNights { get; set; }


        /// <summary>
        /// Стоимость тура за одного отдыхающего.
        /// </summary>
        public decimal CostPerVacationer { get; set; }


        /// <summary>
        /// Количество отдыхающих, оформленных на тур.
        /// </summary>
        public int NumberVacationers { get; set; }


        /// <summary>
        /// Признак наличия Wi-Fi в туре.
        /// </summary>
        public bool AvailabilityWiFi { get; set; }


        /// <summary>
        /// Доплаты, связанные с туром (например, страховки или сервисные сборы).
        /// </summary>
        public decimal Surcharges { get; set; }
    }
}
