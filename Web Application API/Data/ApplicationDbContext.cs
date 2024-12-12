using Microsoft.EntityFrameworkCore;

namespace Web_Application_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<CrudDetail> CrudDetail { get; set; }
    }
}
