using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Interfaces;
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
            var response = _customerService.GetAllCustomers();
            return Ok(response);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] CustomerEditDTO order)
        {
            long id = order.Id;
            _customerService.DelateCustomers(id);
            return Ok();
        }
        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] CustomerEditDTO order)
        {

            _customerService.EditCustomer(order);
            return Ok();
        }

    }
}
