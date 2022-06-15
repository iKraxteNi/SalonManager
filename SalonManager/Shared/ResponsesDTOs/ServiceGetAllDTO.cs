namespace SalonManager.Shared.ResponsesDTOs
{
    public class ServiceGetAllDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public string Note { get; set; }
        public bool IsDelate { get; set; } 
    }
}
