using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.Data.Models
{
    [Table("OrderLine")]
    public class OrderLine
    {
        public int OrderLinetId { get; set; }        
        public int? Quantity { get; set; }        
        public decimal? UnitPrice { get; set; }  
        [Range(1,100,ErrorMessage ="Цена должна быть между {0} и {1}")]
        public decimal? Price { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}
