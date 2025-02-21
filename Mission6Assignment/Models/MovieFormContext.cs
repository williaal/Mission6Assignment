using Microsoft.EntityFrameworkCore;

namespace Mission6Assignment.Models
{
    public class MovieFormContext : DbContext
    {
        public MovieFormContext(DbContextOptions<MovieFormContext> options) : base(options) 
        { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
