using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DoorsAn1.Data.Models
{
   public class User : IdentityUser
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public int? RoleId { get; set; }
        //public Role Role { get; set; }
    }
}
