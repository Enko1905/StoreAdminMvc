using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Adres tablosu
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required, MaxLength(100)]
        public string Street { get; set; }
        [ForeignKey("CityDistricts")]
        public int CityDistrictId { get; set; }
        public CityDistricts CityDistricts { get; set; }


        [Required, MaxLength(500)]
        public string Adress { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
