namespace LastMinuteTours.Entities
{
    public class TourModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Direction Direction { get; set; }
        public DateTime DepartureDate { get; set; }
        public int NumberNights { get; set; }
        public decimal CostPerVacationer { get; set; }
        public int NumberVacationers { get; set; }
        public bool AvailabilityWiFi { get; set; }
        public decimal Surcharges { get; set; }
    }
}
