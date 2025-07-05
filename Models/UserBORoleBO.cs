namespace credirect_api.Models
{
    public class UserBORoleBO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserBO? User { get; set; }

        public int RoleId { get; set; }
        public RoleBO? Role { get; set; }
    }

}
