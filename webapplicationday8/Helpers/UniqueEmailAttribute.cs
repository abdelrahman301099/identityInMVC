using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using webapplicationday8.Context;
using webapplicationday8.Models;

namespace webapplicationday8.Helpers
{
    public class UniqueEmailAttribute: ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DrugContext drugContext = validationContext.GetService<DrugContext>();
            User u = validationContext.ObjectInstance as User;

            string uEmail = value.ToString();
            if (drugContext.Users.Any(t => t.Email == uEmail))
                return new ValidationResult("The Email Name is not Unique");
            return ValidationResult.Success;
        }
    }
}
