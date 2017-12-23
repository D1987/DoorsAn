using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DoorsAn1.Data.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ICategoryRepository _categoryRepository;       
        private readonly AppDbContext _db;
        private IHostingEnvironment _environment;

        public CategoryController(ICategoryRepository categoryRepository, AppDbContext context, IHostingEnvironment environment)
        {
            _categoryRepository = categoryRepository;            
            _db = context;
            _environment = environment;
        }

        #region Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            IQueryable<Category> categories = _db.Categories;
            var categoryViewModel = new CategoryViewModel
            {
                Categories = categories               
            };
            return View(categoryViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов  
                using (var binaryReader = new BinaryReader(categoryViewModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)categoryViewModel.Image.Length);
                }
                // установка массива байтов
                categoryViewModel.Category.Image = imageData;
            }

            _db.Categories.Add(categoryViewModel.Category);
            await _db.SaveChangesAsync();
            return Redirect("/Category/Create");
        }

        #endregion       

        # region Edit
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id, string name)
        {
            if (id != null)
            {
                Category category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
                if (category != null)
                {
                    CategoryViewModel viewModel = new CategoryViewModel
                    {                        
                        Category = category
                    };
                    return View(viewModel);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (categoryViewModel.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов  
                using (var binaryReader = new BinaryReader(categoryViewModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)categoryViewModel.Image.Length);
                }
                // установка массива байтов
                categoryViewModel.Category.Image = imageData;
            }
            _db.Categories.Update(categoryViewModel.Category);
            await _db.SaveChangesAsync();
            return Redirect("/Category/Create");
        }

        #endregion

        #region Delete
        [HttpGet]
        [ActionName("Delete")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Category category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
                if (category != null)
                {
                    CategoryViewModel viewModel = new CategoryViewModel
                    {
                        Category = category
                    };
                    return View(viewModel);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Category category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
                if (category != null)
                {
                    //Category category = new Category { Id = id.Value };
                    //_db.Entry(Category).State = EntityState.Deleted;
                    _db.Categories.Remove(category);
                    await _db.SaveChangesAsync();
                    return Redirect("/Category/Create");
                }
            }
            return NotFound();
        }

        #endregion 
    }
}
