using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Product Product { get; set; } 
        public IFormFile Image { get; set; }
    }
}
