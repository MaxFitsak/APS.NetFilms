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
                new Film{ Id = 4, FilmName = "Ex Machina", 
                    Description = "A talented programmer from a major corporation travels to the secluded home of its " +
                                  "creator to conduct a Turing test with a humanoid artificial intelligence.",
                    Genre = "Sci-fi, psychological thriller", Photo = "ExMachina.jpg", Rating = 7.7},
                new Film{ Id = 5, FilmName = "Pirates of Silicon Valley", 
                    Description = "A legendary chronicle of the dawn of the PC era: the rivalry between the young " +
                                  "Steve Jobs (Apple) and Bill Gates (Microsoft), featuring their rise to prominence, " +
                                  "ambitions, and the appropriation of others' ideas.",
                    Genre = "Biography, drama", Photo = "Pirates-of-Silicon-Valley.jpg", Rating = 7.5},
                new Film{ Id = 6, FilmName = "Tetris", 
                    Description = "The true, gripping story of game designer Henk Rogers, who navigated the bureaucracy " +
                                  "of the USSR during the Perestroika era to secure the rights to the legendary game " +
                                  "code created by Alexey Pajitnov.",
                    Genre = "Thriller, biography, comedy", Photo = "Tetris.jpg", Rating = 7.4},
                new Film{ Id = 7, FilmName = "Office Space", 
                    Description = "The definitive comedy about the life of a typical 90s developer: burnout, the " +
                                  "senseless management at Initech, and an attempt to plant a virus in corporate " +
                                  "software that skims off fractions of a cent.",
                    Genre = "Comedy", Photo = "OfficeSpace.jpg", Rating = 6.9},
                new Film{ Id = 8, FilmName = "Antitrust", 
                    Description = "A promising programmer lands his dream job at a massive IT corporation, but " +
                                  "soon discovers the bloody methods the company uses to obtain competitors' source code.",
                    Genre = "Thriller, drama", Photo = "Antitrust.jpg", Rating = 7.0},
                new Film{ Id = 9, FilmName = "Snowden", 
                    Description = "The true story of programmer and special agent Edward Snowden, who exposed the " +
                                  "scale of global surveillance of citizens by US intelligence agencies via digital systems.",
                    Genre = "Biography, thriller", Photo = "Snowden.jpg", Rating = 7.0},
                new Film{ Id = 10, FilmName = "Hackers", 
                    Description = "A 90s classic about rebellious teenage computer whizzes who accidentally " +
                                  "stumble upon a malicious worm capable of sinking a global oil tanker.",
                    Genre = "Thriller, crime, drama", Photo = "Hackers.jpg", Rating = 6.9}
            );
        }
    }
}