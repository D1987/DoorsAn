using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DoorsAn1.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Producer { get; set; }

        [Required]
        public int Price { get; set; }
       
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Required]
        public bool Status { get; set; }

        public byte[] Image { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
