using System.ComponentModel.DataAnnotations;

namespace FilmMVC.Models
{
    public class Film
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть назву фільму")]
        [Display(Name = "Фільм")]
        public required string FilmName { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть жанр фільму")]
        [Display(Name = "Жанр")]
        public required string Genre { get; set; }

        [Required(ErrorMessage = "Будь ласка, введіть опис фільму")]
        [Display(Name = "Опис")]
        public required string Description { get; set; }

        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }

        [Display(Name = "Назва фотографії")]
        public string? Photo { get; set; }
    }
}