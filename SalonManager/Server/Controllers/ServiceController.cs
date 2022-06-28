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
        public IActionResult GetAll()
        {
            var response = _serviceService.GetAllService();
            return Ok(response);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete( [FromBody] ServiceEditDTO order)
        {
            long id = order.Id;
            _serviceService.DelateService(id);
            return Ok();
        } 

        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] ServiceEditDTO order)
        {
            
            _serviceService.EditService(order);
            return Ok();
        }

    }
}
