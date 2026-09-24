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
                    Description = "The story of how Harvard student Mark Zuckerberg created Facebook—from the first " +
                                  "lines of code written in his dorm room to high-profile lawsuits filed by former " +
                                  "friends.",
                    Genre = "Biography, drama", Photo = "The-Social-Network-Poster-Pic-2.jpg", Rating = 7.8 },
                new Film{ Id = 2, FilmName = "The Imitation Game", 
                    Description = "British mathematician and computer science pioneer Alan Turing attempts to crack the " +
                                  "German Enigma cipher machine during World War II.",
                    Genre = "Biographica, war drama", Photo = "TheImitationGame.jpg", Rating = 8.0},
                new Film{ Id = 3, FilmName = "Who Am I", 
                    Description = "Benjamin, a young, reclusive German coding genius, joins CLAY—a daring hacker group" +
                                  " that attracts the attention of intelligence agencies and the darknet.",
                    Genre = "Thriller, crime, detective", Photo = "WhoAmI.jpg", Rating = 7.5},
                new Film{ Id = 4, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 5, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 6, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 7, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 8, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 9, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1},
                new Film{ Id = 10, FilmName = "", 
                    Description = "",
                    Genre = "", Photo = "", Rating = 1}
            );
        }
    }
}