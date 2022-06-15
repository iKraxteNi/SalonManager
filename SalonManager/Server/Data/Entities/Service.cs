namespace SalonManager.Entities
{
    public class Service
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public bool IsDelate { get; set; } = false;
        public List<Appointment> Appointments { get; set; }


    }
}
