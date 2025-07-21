using System.ComponentModel.DataAnnotations.Schema;

namespace credirect_api.Models
{
    [Table("role_bo")]
    public class RoleBO
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
    }

}
