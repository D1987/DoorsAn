using System.ComponentModel.DataAnnotations;

namespace DoorsAn1.Data.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 250 символов")]
        public string Name { get; set; }

        public string Producer { get; set; }

        [Required(ErrorMessage = "Не указана цена")]
        [RegularExpression(@"[0-9].*")]
        public int Price { get; set; }        

        [Required(ErrorMessage = "Введите описание товара")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Не указан статус")]
        public bool Status { get; set; }

        //[Required]
        //[DataType(DataType.Upload)]
        //[Display(Name = "foto")]
        //public byte[] Image { get; set; }

        public int InStock { get; set; }

        public int CategoryId { get; set; }

        //[Required(ErrorMessage = "Не выбрана категория!")]
        //public Category Category { get; set; }
    }
}
