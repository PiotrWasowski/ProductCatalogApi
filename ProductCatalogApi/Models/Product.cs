using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.Models
{
    public class Product
    {
        public int Id { get; set; }
            
        [Required(ErrorMessage = "Kod jest wymagany")]
        public string Kod { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Cena nie może być mniejsza niż 0")]
        public decimal Cena { get; set; }
    }
}
