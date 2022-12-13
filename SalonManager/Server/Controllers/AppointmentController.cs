using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Entities;
using SalonManager.Server.Interfaces;

using SalonManager.Shared.ResponsesDTOs;


namespace SalonManager.Server.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;


        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }



        

        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            // var response = _appointmentService.GetAllAppointments();
            // return Ok(response);
            return Ok(_mapper.Map<IEnumerable<AppointmentDto>>(_appointmentService.GetAllAppointments()));
        }

        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] AppointmentDto model)
        {
            _appointmentService.EditAppointment(_mapper.Map<Appointment>(model));
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




