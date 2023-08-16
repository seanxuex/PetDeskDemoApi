using System.ComponentModel.DataAnnotations;

namespace PetDeskDemoApi.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public string AppointmentType { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime requestedDateTimeOffset { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}
