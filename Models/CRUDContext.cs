using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Models
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) { }
        public DbSet <Meal> Dishes {get;set;}
    }
}