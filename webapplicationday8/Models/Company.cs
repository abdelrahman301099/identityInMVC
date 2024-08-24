using System.ComponentModel;
using webapplicationday8.Helpers;

namespace webapplicationday8.Models
{
    public class Company
    {
        public int ID { get; set; }
        [DisplayName("Company")]
        [UniqueCompanyName]
        public string Name { get; set; }
        public virtual List<Drug>? Drugs { get; set; } = new List<Drug>();
    }
}
