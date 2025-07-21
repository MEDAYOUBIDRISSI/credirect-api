using System.ComponentModel.DataAnnotations.Schema;

namespace credirect_api.Models
{
    [Table("user_bo")]
    public class UserBO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
