using FilmMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Films.Controllers
{   
    // Використання Primary Constructor (C# 12)
    public class FilmsController(FilmContext context, IWebHostEnvironment webHostEnvironment) : Controller
    {
        private readonly FilmContext _context = context;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        // GET: Students
        // AsNoTracking() використовується для оптимізації читання (Read-Only)
        public async Task<IActionResult> Index() =>
            View(await _context.Films.AsNoTracking().ToListAsync());

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            // AsNoTracking() значно зменшує навантаження на пам'ять,
            // оскільки EF Core не відстежує сутності
            var film = await _context.Films
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            return film is null ? NotFound() : View(film);
        }

        //// GET: Students/Create
        public IActionResult Create() => View();

        //// POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilmName,Description,Genre,Rating")] Film film, IFormFile? photoFile)
        {
            ModelState.Remove("Photo");
            
           if (!ModelState.IsValid) return View(film);
            
           if (photoFile != null && photoFile.Length > 0)
           {
               string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Photos");
               Directory.CreateDirectory(uploadsFolder);
               
               string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photoFile.FileName);
               string filePath = Path.Combine(uploadsFolder, uniqueFileName);

               using (var fileStream = new FileStream(filePath, FileMode.Create))
               {
                   await photoFile.CopyToAsync(fileStream);
               }
               
               film.Photo = uniqueFileName;
           }
           
            _context.Add(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            // AsNoTracking() значно зменшує навантаження на пам'ять,
            // оскільки EF Core не відстежує сутності
            var film = await _context.Films
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            
            return film is null ? NotFound() : View(film);
        }

        // POST: Students/Edit/5
        [HttpPost]
           [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FilmName,Description,Genre,Rating,Photo")] Film film, IFormFile? photoFile)
            {
                if (id != film.Id) return NotFound();
                ModelState.Remove("Photo");
                if (!ModelState.IsValid) return View(film);

                try
                {
                    if (photoFile != null && photoFile.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Photos");
                        Directory.CreateDirectory(uploadsFolder);

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(photoFile.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await photoFile.CopyToAsync(fileStream);
                        }
                        
                        film.Photo = uniqueFileName;
                    }

                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.Films.AnyAsync(e => e.Id == film.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

        //    // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
            {
                if (id is null) return NotFound();

                var film = await _context.Films
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.Id == id);

                return film is null ? NotFound() : View(film);
            }

            // POST: Students/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var film = await _context.Films.FindAsync(id);
                if (film is not null)
                {
                    _context.Films.Remove(film);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            
        }
    }
