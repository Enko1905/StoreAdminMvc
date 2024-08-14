using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    // Şehir tablosu
    public class City
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public string? PlateCode { get; set; }
        public ICollection<CityDistricts> CityDistricts { get; set; }
    }

}
