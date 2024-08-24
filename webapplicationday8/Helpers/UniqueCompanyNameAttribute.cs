using NuGet.DependencyResolver;
using System.ComponentModel.DataAnnotations;
using webapplicationday8.Context;
using webapplicationday8.Models;

namespace webapplicationday8.Helpers
{
    public class UniqueCompanyNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DrugContext drugContext = validationContext.GetService<DrugContext>();
            Company company = validationContext.ObjectInstance as Company;

            string compName = value.ToString();
            if (drugContext.Companies.Any(t => t.Name == compName && t.ID != company.ID))
                return new ValidationResult("The Company Name is not Unique");
            return ValidationResult.Success;
        }
    }
}
