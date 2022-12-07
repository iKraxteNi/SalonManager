using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Interfaces;
using SalonManager.Server.Services;

using SalonManager.Shared.ResponsesDTOs;


namespace SalonManager.Server.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        // GET: api/<ValuesController>}/{start}&{end}
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] AppointmentGetDTO query)
        {
            var response = _appointmentService.GetAllAppointments(query);
            return Ok(response);
        }
        //public IEnumerable<AppointmentDto> GetAllAppointments()
        //{
        //    var appointments = _appointmentService.GetAllAppointments();
        //    return (IEnumerable<AppointmentDto>)Ok(appointments);
        //}
        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] AppointmentDto model)
        {

            _appointmentService.EditAppointment(model);
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] AppointmentDto model)
        {
            long id = model.Id;
            _appointmentService.DelateAppointment(id);
            return Ok();
        }
    }



}




