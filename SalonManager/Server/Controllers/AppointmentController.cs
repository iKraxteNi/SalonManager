using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SalonManager.Entities;
using SalonManager.Server.Interfaces;
using SalonManager.Server.Validators;
using SalonManager.Server.Validators.AppointmentDtoValidators;
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

            return Ok(_mapper.Map<IEnumerable<AppointmentDto>>(_appointmentService.GetAllAppointments()));
        }

        [HttpPost]
        [Route("editadd")]
        public async Task<IActionResult> Edit([FromBody] AppointmentDto model)
        {
            AppointmentEditAddDtoValidator validator = new();

            var validResult = validator.Validate(model);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);


            _appointmentService.EditAppointment(_mapper.Map<Appointment>(model));
            return Ok(new ResponseDto { Status = "Success", Message = "Appointment edit/add successfully" });
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] AppointmentDto model)
        {
            AppointmentDeleteDtoValidator validator = new();

            var validResult = validator.Validate(model);
            if (!validResult.IsValid)
                return BadRequest(validResult.Errors);

            long id = model.Id;
            _appointmentService.DelateAppointment(id);
            return Ok(new ResponseDto { Status = "Success", Message = "Appointment deleted successfully" });
        }
    }



}




