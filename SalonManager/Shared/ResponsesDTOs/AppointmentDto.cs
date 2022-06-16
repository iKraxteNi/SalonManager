namespace SalonManager.Shared.ResponsesDTOs
{
    public class AppointmentDto
    {

        public long Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

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
