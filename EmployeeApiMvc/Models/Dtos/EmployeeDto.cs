using System.ComponentModel;

namespace EmployeeApiMvc.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Od Birth")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }
        public double Salary { get; set; }

        [DisplayName("Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
