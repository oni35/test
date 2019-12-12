using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace module1.Models.Validators
{
    public class NombreDeJourValide : ValidationAttribute
    {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            Object data = type.GetProperty("DateDebut").GetValue(instance, null);
            DateTime debut = (DateTime)data;

            DateTime dateLivraison;
            DateTime.TryParse(value.ToString(), out dateLivraison);

            int nbDeJour = Convert.ToInt32(dateLivraison - debut); 

            if (nbDeJour < 1)
            {
                return new ValidationResult("Nombre de jour incorrect");
            }

            return ValidationResult.Success;
        }
    }
}