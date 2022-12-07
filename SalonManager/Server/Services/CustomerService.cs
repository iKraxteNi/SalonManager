using SalonManager.Entities;
using SalonManager.Server.Data;
using SalonManager.Server.Interfaces;
using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Services
{
    public class CustomerService : ICustomerService
    {

        public ApplicationDbContext _dbContext;

        public CustomerService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CustomerGetDTO> GetAllCustomers()
        {
            var customers = _dbContext.Customers.Where(p => p.IsDelate == false).Select(p => new CustomerGetDTO()
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                FullNameCastomer = p.FirstName + " " + p.LastName,
                PhoneNumber = p.PhoneNumber,
                Note = p.Note,
                IsDelate = p.IsDelate,

            }).ToList();

            //service
            return new List<CustomerGetDTO>(customers);
        }

        public void DelateCustomers(long Id)
        {

            var delete = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();

            _dbContext.Entry(delete).CurrentValues.SetValues(delete.IsDelate = true);
            _dbContext.SaveChanges();

        }
        public void EditCustomer(CustomerEditDTO model)
        {

            if (model.Id == 0)
            {
                var NewCustomer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Note = model.Note,
                    IsDelate = false


                };

                _dbContext.Customers.Add(NewCustomer);
            }
            else
            {
                var cusToUpdate = _dbContext.Customers.Where(p => p.Id == model.Id).FirstOrDefault();
                _dbContext.Entry(cusToUpdate).CurrentValues.SetValues(model);
            }
            _dbContext.SaveChanges();

        }


    }
}
