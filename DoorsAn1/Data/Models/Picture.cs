using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.Data.Models
{
    [Table("Picture")]
    public class Picture
    {
        public int PictureId { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }
    }
}
