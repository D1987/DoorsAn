using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace DoorsAn1.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Не указано имя!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Name { get; set; }

        public string Producer { get; set; }

        [Required(ErrorMessage = "Не указана стоимость!")]
        public int Price { get; set; }        

        [Required(ErrorMessage = "Не указано описание!")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Не указан статус!")]
        public bool Status { get; set; }

        public byte[] Image { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Не выбрана категория!")]
        public Category Category { get; set; }
    }
}
