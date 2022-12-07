using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Interfaces
{
    public interface ICustomerService
    {
        void DelateCustomers(long Id);
        void EditCustomer(CustomerEditDTO model);
        List<CustomerGetDTO> GetAllCustomers();
    }
}