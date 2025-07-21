using System.ComponentModel.DataAnnotations.Schema;

namespace credirect_api.Models
{
    [Table("user_bo_role_bo")]
    public class UserBORoleBO
    {
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
        public UserBO? User { get; set; }

        [Column("role_id")]
        public int RoleId { get; set; }
        public RoleBO? Role { get; set; }
    }

}
