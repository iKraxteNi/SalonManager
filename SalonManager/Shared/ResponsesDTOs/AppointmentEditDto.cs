namespace SalonManager.Shared.ResponsesDTOs
{
    public class AppointmentEditDto
    {

        public long Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public long CustomerId { get; set; }

        public string FullNameCastomer { get; set; }

        public long ServiceId { get; set; }
        public decimal ServicePrice { get; set; }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }




    }
}
