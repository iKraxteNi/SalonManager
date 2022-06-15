namespace SalonManager.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName   { get; set; }
        public string PhoneNumber { get; set; }
        public string Note { get; set; }

        public bool IsDelate { get; set; } = false;
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public List<Appointment> Appointments { get; set; } 
        
    }
    
}
