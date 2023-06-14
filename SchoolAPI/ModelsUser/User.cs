using System.ComponentModel.DataAnnotations;

namespace SchoolAPI.ModelsUser
{
    public class User
    {
        [Key]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
