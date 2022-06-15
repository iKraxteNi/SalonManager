
using SalonManager.Server.Data;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Services
{
    public class ServiceService
    {
        public ApplicationDbContext _dbContext;

        public ServiceService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ServiceGetAllDTO> GetAllService()
        {
            var service = _dbContext.Servicess.Select(x => new ServiceGetAllDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Note = x.Note,
                IsDelate= x.IsDelate
            }).ToList();
            return service;
        }
    }
}
