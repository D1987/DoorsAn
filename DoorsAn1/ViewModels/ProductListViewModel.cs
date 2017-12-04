using System.Collections.Generic;
using DoorsAn1.Data.Models;

namespace DoorsAn1.ViewModels
{
    public class ProductListViewModel
    {
        public Product Product { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public string Name { get; set; }
    }
}
