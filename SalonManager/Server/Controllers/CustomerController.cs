using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Interfaces;
using SalonManager.Server.Validators;
using SalonManager.Server.Validators.CustomerDtoValidators;
using SalonManager.Shared.ResponsesDTOs;


namespace SalonManager.Server.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] CustomerEditDTO order)
        {
            CustomerDeleteDtoValidator validator = new();

            var validResult = validator.Validate(order);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            long id = order.Id;
            _customerService.DelateCustomers(id);
            return Ok(new ResponseDto { Status = "Success",Message = "Customer deleted successfully" } );
        }
        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] CustomerEditDTO order)
        {
            CustomerDeleteDtoValidator validator = new();

            var validResult = validator.Validate(order);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            _customerService.EditCustomer(order);
            return Ok(new ResponseDto { Status = "Success", Message = "Customer edit/add successfully" });
        }

    }
}
