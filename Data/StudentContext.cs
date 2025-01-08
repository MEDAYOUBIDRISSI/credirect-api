using credirect_api.Models;
using Microsoft.EntityFrameworkCore;

namespace credirect_api.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<StudentDetail> StudentDetail { get; set; }
    }
}