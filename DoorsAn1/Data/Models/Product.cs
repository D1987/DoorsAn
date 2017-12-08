using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DoorsAn1.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        public string Producer { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Введите описание товара")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Не указан статус")]
        public bool Status { get; set; }

        public byte[] Image { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
