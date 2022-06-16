namespace SalonManager.Entities
{
    public class Appointment
    {
        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        public string FullNameCastomer { get; set; }

        public Service Service { get; set; }
        public long ServiceId { get; set; }
        public decimal ServicePrice { get; set; }

        public User User { get; set; }
        public long? UserId { get; set; }

        public string Note { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
