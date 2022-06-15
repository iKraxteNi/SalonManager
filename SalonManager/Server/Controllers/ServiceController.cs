using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Services;
using SalonManager.Shared.ResponsesDTOs;


namespace SalonManager.Server.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServiceController(ServiceService serviceService)
        {
            _serviceService = serviceService;   
        }

        // GET: api/<ValuesController>
        [Route("getAll")]
        [HttpGet]

        public IEnumerable<ServiceGetAllDTO> GetAllService ()
        {
            var service = _serviceService.GetAllService();
            return (IEnumerable<ServiceGetAllDTO>)Ok(service) ;
        }
    }
}
