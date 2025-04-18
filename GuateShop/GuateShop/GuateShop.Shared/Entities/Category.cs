﻿using System.ComponentModel.DataAnnotations;

namespace GuateShop.Shared.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas  de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
    }
}