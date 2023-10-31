using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {

        public int UserId { get; set; }

        [StringLength(20, ErrorMessage = "Name langrh can't be more than 10.")]
        public string UserName { get; set; }
        [StringLength(10, ErrorMessage = "Name langrh can't be more than 10.")]
        public string Password { get; set; }
        [StringLength(10, ErrorMessage = "Name langrh can't be more than 10.")]
        public string FirstName { get; set; }
        [StringLength(10, ErrorMessage = "Name langrh can't be more than 10.")]
        public string LastName { get; set; }
   


    }
}
