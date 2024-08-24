using System.ComponentModel.DataAnnotations;

namespace webapplicationday8.Helpers
{
    public class DateLimitAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime date = (DateTime)value;
            if (date.Year <= DateTime.Now.Year && date.Year >= 2022)
                return true;
            return false;
        }
    }
}
