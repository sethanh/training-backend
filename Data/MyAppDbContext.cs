using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class MyAppDbContext(DbContextOptions<MyAppDbContext> options) : DbContext(options)
    {

        // Define your DbSets here
        public DbSet<Phone> Phones { get; set; }
    }
}
