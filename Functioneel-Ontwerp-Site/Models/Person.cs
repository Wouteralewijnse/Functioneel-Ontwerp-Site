using System.ComponentModel.DataAnnotations;

namespace Functioneel_Ontwerp_Site.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Gelieve uw naam in te vullen")]
        public string Firstname { get; set; }
        [Required(ErrorMessage ="Achternaam is een verplicht veld")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Emailaddres is verplicht")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
    }
}
