using System.ComponentModel.DataAnnotations;

namespace Deiarts.Domain.Enums;

public enum UnitOfMeasureType
{
    [Display(Name = "Quilograma", ShortName = "kg")]
    Kilogram,

    [Display(Name = "Grama", ShortName = "g")]
    Gram,

    [Display(Name = "Litro", ShortName = "L")]
    Liter,

    [Display(Name = "Mililitro", ShortName = "mL")]
    Milliliter,

    [Display(Name = "Metro", ShortName = "m")]
    Meter,

    [Display(Name = "Centímetro", ShortName = "cm")]
    Centimeter,

    [Display(Name = "Polegada", ShortName = "in")]
    Inch,

    [Display(Name = "Pé", ShortName = "ft")]
    Foot,

    [Display(Name = "Jarda", ShortName = "yd")]
    Yard,

    [Display(Name = "Unidade", ShortName = "un")]
    Piece
}