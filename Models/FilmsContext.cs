using Microsoft.EntityFrameworkCore;

namespace FilmMVC.Models
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, FilmName = "The Social Network",
                    Description = "The story of how Harvard student Mark Zuckerberg created Facebook—from the first lines of code written in his dorm room to high-profile lawsuits filed by former friends.",
                    Genre = "Biography, drama", Photo = "The-Social-Network-Poster-Pic-2.jpg", Rating = 7.8 }

            );
        }
    }
}