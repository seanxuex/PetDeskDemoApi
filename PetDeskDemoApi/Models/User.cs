using System.ComponentModel.DataAnnotations;

namespace PetDeskDemoApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string VetDataId { get; set; }
    }
}
