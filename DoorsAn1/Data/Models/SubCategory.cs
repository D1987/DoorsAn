using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.Data.Models
{
    [Table("SubCategory")]
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
