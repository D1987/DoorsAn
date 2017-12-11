using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoorsAn1.Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext context)
        {            
            _db = context;           
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoryViewModel
            {
                Categories = await _db.Categories.ToListAsync()
            };
            return View(viewModel);            
        }
    }
}
