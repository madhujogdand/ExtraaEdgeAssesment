using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExtraaEdgeAssesment.Models
{
    [Table("users")]
    public class Users
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class UserLogin
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class UserConstants
    {
        // fetch the user & its role from DB
        public static List<Users> Users = new()
            {
                    new Users(){ Email="extraaedge@gmail.com",Password="edge@123"},

            };

    }

}

