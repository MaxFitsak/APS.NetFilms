using System.ComponentModel.DataAnnotations;

namespace FilmMVC.Models
{
    public class Film
    {
        [Display(Name = "Ідентифікатор")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле є обов'язковим для заповнення.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Від 3 до 50 символів")]
        [Display(Name = "Фільм")]
        public required string FilmName { get; set; }

        [Required(ErrorMessage = "Поле є обов'язковим для заповнення.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Від 3 до 50 символів")]
        [Display(Name = "Жанр")]
        public required string Genre { get; set; }

        [Required(ErrorMessage = "Поле є обов'язковим для заповнення.")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "Від 3 до 50 символів")]
        [Display(Name = "Опис")]
        public required string Description { get; set; }
    
        [Required(ErrorMessage = "Поле є обов'язковим для заповнення.")]
        [Range(0, 10.0, ErrorMessage = "Неприпустимий вік.")]
        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }

        [Display(Name = "Назва фотографії")]
        public string? Photo { get; set; }
    }
}