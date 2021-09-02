using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models
{
    public class Product : Entity
    {
        [DisplayName("Nome do produto")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Preço")]
        public double Price { get; set; }
        public virtual Section Sector { get; set; }

        public Product()
        {
        }

        public Product(string name, double price, Section sector)
        {
            Name = name;
            Price = price;
            Sector = sector;
        }
    }
}