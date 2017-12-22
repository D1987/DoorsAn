using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace DoorsAn1.Data.Models
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            CartItems = new HashSet<CartItem>();
            OrderLines = new HashSet<OrderLine>();
            Pictures = new HashSet<Picture>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 250 символов")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Введите описание товара")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Не указана цена")]
        [RegularExpression(@"[0-9].*")]
        public decimal UnitPrice { get; set; }
        //public int? UnitsInStock { get; set; }  
        public string Producer { get; set; }
        [Required(ErrorMessage = "Не указан статус")]
        public bool Status { get; set; }
        public byte[] ProductImagePath { get; set; }        
        public int? CategoryId { get; set; }       
        public int? PictureId { get; set; }
        [Required(ErrorMessage = "Не выбрана категория!")]
        public virtual Category Categories { get; set; }
        //public virtual ICollection<CartItem> CartItems { get; set; }
        //public virtual ICollection<OrderLine> OrderLines { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
