using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoorsAn1.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 250 символов")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
