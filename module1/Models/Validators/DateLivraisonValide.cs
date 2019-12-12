using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace module1.Models.Validators
{
    public class DateLivraisonValide : ValidationAttribute
    {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            //Réflexion = être capable d'accéder à une fonctionnalité sans connaitre la classe dans laquelle on est
            //Introflexion = regarde une fonctionnalité sans connaitre la classe dans laquelle on est
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            Object data = type.GetProperty("DateDebut").GetValue(instance, null);
            DateTime debut = (DateTime)data;

            DateTime dateLivraison;
            DateTime.TryParse(value.ToString(), out dateLivraison);

            if (dateLivraison < debut)
            {
                return new ValidationResult("Date de livraison incorrecte");
            }

            return ValidationResult.Success;
        }
    }
   
}
