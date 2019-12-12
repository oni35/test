using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace module1.Models.Validators
{
    public class DateDebutValide : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateDebut;
            DateTime.TryParse(value.ToString(), out dateDebut);

            if (dateDebut < DateTime.Now)
            {
                return new ValidationResult("Date de Début incorrecte");
            }

            return ValidationResult.Success;
        }
    }
}