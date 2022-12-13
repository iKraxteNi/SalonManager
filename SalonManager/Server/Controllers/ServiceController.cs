using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Interfaces;
using SalonManager.Shared.ResponsesDTOs;
using SalonManager.Server.Validators.CustomerDtoValidators;
using SalonManager.Server.Validators;

namespace SalonManager.Server.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/<ValuesController>
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serviceService.GetAllService());
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] ServiceEditDTO order)
        {
            ServiceDeleteDtoValidator validator = new();

            var validResult = validator.Validate(order);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            long id = order.Id;
            _serviceService.DelateService(id);
            return Ok(new ResponseDto { Status = "Success", Message = "Service delete successfully" });
        }

        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] ServiceEditDTO order)
        {
            ServicerEditAddDtoValidator validator = new();

            var validResult = validator.Validate(order);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            _serviceService.EditService(order);
            return Ok(new ResponseDto { Status = "Success", Message = "Service edit/add successfully" });
        }

    }
}
