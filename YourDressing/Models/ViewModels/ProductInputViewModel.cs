using System.Collections.Generic;

namespace YourDressing.Models.ViewModels
{
    public class ProductInputViewModel
    {
        public Product Product { get; set; }
        public List<Section> Sections { get; set; }

        public ProductInputViewModel()
        
        {
        }

        public ProductInputViewModel(List<Section> sections)
        {
            Sections = sections;
        }

        public ProductInputViewModel(Product product, List<Section> sections)
        {
            Product = product;
            Sections = sections;
        }
    }
}
