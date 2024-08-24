using System.ComponentModel.DataAnnotations;

namespace webapplicationday8.Helpers
{
    public class ExpiredDateAtrribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime date = (DateTime)value;
            if(date.Year <= 2024)
                return false;
            return true;
        }
    }
}
