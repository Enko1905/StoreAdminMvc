using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Şehir Bölgesi tablosu
    public class CityDistricts
    {
        [Key]
        public int CityDistrictsId { get; set; }

        [MaxLength(100)]
        public string DistrictsName { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }
    }

}
