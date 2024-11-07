using System.ComponentModel.DataAnnotations;

namespace Deiarts.Domain.Enums;

public enum UnitOfMeasureType
{
    [Display(Name = "Quilograma", ShortName = "kg")]
    Kilogram = 1,

    [Display(Name = "Grama", ShortName = "g")]
    Gram = 2,

    [Display(Name = "Litro", ShortName = "L")]
    Liter = 11,

    [Display(Name = "Mililitro", ShortName = "mL")]
    Milliliter = 12,

    [Display(Name = "Metro", ShortName = "m")]
    Meter = 21,

    [Display(Name = "Centímetro", ShortName = "cm")]
    Centimeter = 22,

    [Display(Name = "Polegada", ShortName = "in")]
    Inch = 31,

    [Display(Name = "Pé", ShortName = "ft")]
    Foot = 32,

    [Display(Name = "Jarda", ShortName = "yd")]
    Yard = 41,

    [Display(Name = "Unidade", ShortName = "un")]
    Piece = 42
}