using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System;
using static System.Net.WebRequestMethods;
using PetDeskDemoApi.Models;
using PetDeskDemoApi.Data;
using Azure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.EntityFrameworkCore;

namespace PetDeskDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private const string APPURL = "https://723fac0a-1bff-4a20-bdaa-c625eae11567.mock.pstmn.io/appointments";

        // potentially set up the dbcontext to talk to real databases
        //private readonly AppointmentDbContext _context;

        //public AppointmentController(AppointmentDbContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            try
            {
                HttpClient http = new HttpClient();
                var data = http.GetAsync(APPURL).Result.Content.ReadAsStringAsync().Result;
                // technicall, instead of just provide the json string, 
                // we would connect with the database, get all the data, hopefully the object is set up correctly using Entity Framework
                // that would be done in a "Service" layer/folder, and "Repository" layer/folder
                return Ok(data);
            }
            
                catch (Exception ex)
              {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("/Confirmed")]
        [HttpGet]
        public IActionResult GetConfirmedAppointments()
        {
            // just an idea
            // we could potentially return a list of confirmed appointment
            // only need their appointmentId, so the front end can group the data accordingly
            // or another way would be to modify the existing object of appointment, to have a confirmed field
            // then this call would not be needed
            return Ok();
        }

        // POST: api/Appointment/5
        [HttpPost("{appointmentId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public int PostConfirmedAppointment(int appointmentId)
        {
            // if we are adding the appointmentId into the Confirmed table
            // await _context.Confirmed.AddAsync(appointmentId);
            // await _context.SaveChangesAsync();
            // if we are using the adding a confirmed field way
            // this would be a patch, and change the confirmed to true
            return appointmentId;
        }

        // PATCH: api/Appointment/5
        [HttpPatch("{appointmentId}")]
        public IActionResult UpdateAppointmentTime(int appointmentId)
        {
            // potentially take in [FromBody] JsonPatchDocument<Appointment> patchDocument
            try
            {
                // some potential logic to update only the appointment time of the specific appointment
                //if (patchDocument == null)
                //    return BadRequest();

                //var theApp = await _context.Appointment.FindAsync(appointmentId);

                //if (theApp == null)
                //    return BadRequest();

                //patchDocument.ApplyTo(theApp, ModelState);


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("/Confirmed/{appointmentId}")]
        [HttpDelete]
        public IActionResult UnconfirmAppointment(int appointmentId)
        {
            try
            {
                //var confirmedAppToDelete = await _context.Confirmed.FindAsync((appointmentId);

                //if (confirmedAppToDelete == null)
                //{
                //    return NotFound($"Appointment with Id = {appointmentId} not found");
                //}

                //return _context.Confirmed.Remove(appointmentId)

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }

    }
}