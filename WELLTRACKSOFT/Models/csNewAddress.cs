using System.ComponentModel.DataAnnotations;

namespace WELLTRACKSOFT.Models
{
    public class csNewAddress
    {

        public int id { get; set; }

        [MaxLength(50)]
        [Display(Name ="Nick Name")]
        public string NickName { get; set; }

       public TabStreetAddress TabStreetAddress { get; set; }
        [Display(Name = "Place Of Service")]
        public int placeofserviceid { get; set; }

    }
}
