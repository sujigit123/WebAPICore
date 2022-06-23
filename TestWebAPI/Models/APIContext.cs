using Microsoft.EntityFrameworkCore;

namespace TestWebAPI.Models
{
    public class APIContext:DbContext
    {
        public APIContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<DataStore> dataStores { get; set; }
    }      
}
