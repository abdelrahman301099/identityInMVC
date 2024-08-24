using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using webapplicationday8.Helpers;

namespace webapplicationday8.Models
{
    public class Drug
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="the name must be more than 3") ]
        public string Name { get; set; }


        [Required(ErrorMessage = "The Description is needed")]
        public string Description { get; set; }
     
        [DisplayName("Manufacture Date")]
        [Required(ErrorMessage = "Manfacture date is required")]
        [DateLimitAttribute(ErrorMessage ="Date Should be In the Past or in Current Year")]
        public DateTime ManufactureDate { get; set; }


        [Required(ErrorMessage = "Expired date is required")]
        [DisplayName("Expiration Date")]
        [ExpiredDateAtrribute(ErrorMessage = "Date Should be In the Feutur")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "The Image is needed")]
        public string ImagePath { get; set; }
        [ForeignKey("Company")]
        public int CompanyID { get; set; }
        //navigational prop
        public virtual Company? Company { get; set; }
    }
}
