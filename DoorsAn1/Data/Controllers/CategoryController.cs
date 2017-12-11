using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace DoorsAn1.Data.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _categoryRepository;
       // private readonly IProductRepository _productRepository;
        private readonly AppDbContext _db;
        private IHostingEnvironment _environment;

        public CategoryController(ICategoryRepository categoryRepository/*, IProductRepository productRepository*/, AppDbContext context, IHostingEnvironment environment)
        {
            _categoryRepository = categoryRepository;
            //_productRepository = productRepository;
            _db = context;
            _environment = environment;
        }

        # region Create

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {            
            return View(/*_db.Categories.ToList()*/);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();           
            return RedirectToAction("ListForAdmin");
        }

        #endregion
    }
}
