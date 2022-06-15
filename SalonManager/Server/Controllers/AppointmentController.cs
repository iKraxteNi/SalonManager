using Microsoft.AspNetCore.Mvc;
using SalonManager.Server.Services;

using SalonManager.Shared.ResponsesDTOs;


namespace SalonManager.Server.Controllers
{
   // [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        public AppointmentController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        // GET: api/<ValuesController>}/{start}&{end}
        [Route("api/appointment/getAll")]
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
    }



}




