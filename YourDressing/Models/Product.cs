using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YourDressing.Models
{
    public class Product : Entity
    {
        [DisplayName("Nome do produto")]
        [Required (ErrorMessage = "O campo {0} é requirido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres.")]
        public string Name { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "O campo {0} é requirido")]
        public double Price { get; set; }

        [DisplayName("Seção")]
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}