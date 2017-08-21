using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.Models;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoorsAn1.Data
{
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){ }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}
