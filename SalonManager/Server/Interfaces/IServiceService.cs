using SalonManager.Shared.ResponsesDTOs;

namespace SalonManager.Server.Interfaces
{
    public interface IServiceService
    {
        void DelateService(long Id);
        void EditService(ServiceEditDTO model);
        List<ServiceGetAllDTO> GetAllService();
    }
}