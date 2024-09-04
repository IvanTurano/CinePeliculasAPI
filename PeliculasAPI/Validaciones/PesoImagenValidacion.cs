﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class PesoImagenValidacion : ValidationAttribute
    {
        private readonly int pesoMaximoEnMegaBytes;

        public PesoImagenValidacion(int pesoMaximoEnMegaBytes)
        {
            this.pesoMaximoEnMegaBytes = pesoMaximoEnMegaBytes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formfile = value as IFormFile;

            if(formfile == null)
            {
                return ValidationResult.Success;
            }

            if(formfile.Length > pesoMaximoEnMegaBytes * 1024 * 1024)
            {
                return new ValidationResult($"El peso del archivo no debe ser mayor a {pesoMaximoEnMegaBytes}mb");
            }

            return ValidationResult.Success;
        }
    }
}
