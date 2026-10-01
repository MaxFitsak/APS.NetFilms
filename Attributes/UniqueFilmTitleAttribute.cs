using System;
using System.Linq;
using FilmMVC.Models;

namespace FilmMVC.Attributes;

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class UniqueFilmTitleAttribute : ValidationAttribute
{
    public UniqueFilmTitleAttribute() : base("Фільм з такою назвою існує") { }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string title || string.IsNullOrWhiteSpace(title))
        {
            return ValidationResult.Success;
        }

        var db = validationContext.GetService<FilmContext>();
        if (db == null)
        {
            return ValidationResult.Success;
        }

        var idProperty = validationContext.ObjectType.GetProperty("Id");
        int? currentId = idProperty?.GetValue(validationContext.ObjectInstance) as int?;

        bool exists = db.Films.Any(b => b.FilmName.ToLower() == title.ToLower() 
                                        && (!currentId.HasValue || b.Id != currentId.Value));

        if (exists)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}