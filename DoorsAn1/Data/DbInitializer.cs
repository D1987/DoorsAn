using System.Linq;
using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DoorsAn1.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(
            AppDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //This example just creates an Administrator role and one Admin users
        public async void Initialize()
        {
            //create database schema if none exists
            //_context.Database.EnsureCreated();

            //If there is already an Administrator role, abort
            //if (_context.Roles.Any(r => r.Name == "Administrator")) return;

            //Create the Administartor Role
            //await _roleManager.CreateAsync(new IdentityRole("Administrator"));

            //Create the default Admin account and apply the Administrator role
            string user = "admin@admin.by";
            string password = "123456";
            await _userManager.CreateAsync(new IdentityUser { UserName = user, PasswordHash = password });
            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(user), "Administrator");
        }
    }
}
