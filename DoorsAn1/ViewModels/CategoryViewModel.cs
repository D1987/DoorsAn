using DoorsAn1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.ViewModels
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
