using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Http;

namespace DoorsAn1.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        //public FilterViewModel FilterViewModel { get; set; }
        public IFormFile Image { get; set; }
    }
}
