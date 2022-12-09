using AutoMapper;
using SalonManager.Entities;
using SalonManager.Server.Data;
using SalonManager.Server.Interfaces;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Services
{
    public class ServiceService : IServiceService
    {
        public ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ServiceGetAllDTO> GetAllService()
        {                                       //_dbContext.Servicess.Select(x => new ServiceGetAllDTO() 
            //var service = _dbContext.Servicess.Where(p => p.IsDelate == false).Select(p => new ServiceGetAllDTO()
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price,
            //    Duration = p.Duration,
            //    Note = p.Note,
            //    IsDelate = p.IsDelate
            //}).ToList();

            ////service
            //return new List<ServiceGetAllDTO>(service);

            //used AutoMapper

            return (_dbContext.Servicess.Where(p => p.IsDelate == false).Select(p => _mapper.Map< ServiceGetAllDTO>(p)).ToList());
        }

        public void DelateService(long Id)
        {

            var delete = _dbContext.Servicess.Where(x => x.Id == Id).FirstOrDefault();

            _dbContext.Entry(delete).CurrentValues.SetValues(delete.IsDelate = true);
            _dbContext.SaveChanges();

        }
        public void EditService(ServiceEditDTO model)
        {

            if (model.Id == 0)
            {
                var NewService = new Service
                {
                    Name = model.Name,
                    Note = model.Note,
                    Price = model.Price,
                    Duration = model.Duration,
                    IsDelate = false


                };

                _dbContext.Servicess.Add(NewService);
            }
            else
            {
                var servToUpdate = _dbContext.Servicess.Where(p => p.Id == model.Id).FirstOrDefault();
                _dbContext.Entry(servToUpdate).CurrentValues.SetValues(model);
            }
            _dbContext.SaveChanges();

        }


    }
}
