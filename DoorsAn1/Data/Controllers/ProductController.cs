using System;
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
using System.Drawing;

namespace DoorsAn1.Data.Controllers
{
    public class ProductController:Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _db;
        private IHostingEnvironment _environment;

        public ProductController(ICategoryRepository categoryRepository, IProductRepository productRepository, AppDbContext context, IHostingEnvironment environment)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _db = context;
            _environment = environment;
        }

        # region List for admin
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ListForAdmin(string view, int? category, string name, SortState sortOrder = SortState.NameAsc, int page = 1)
        {
            int pageSize = 5;
            IQueryable<Product> products = _db.Products.Include(p => p.Category);

            //фильтрация
            products = Filter(products, category, name);
            // сортировка
            products = Sort(products, sortOrder);
            // пагинация
            var count = await products.CountAsync();
            var items = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            var productListViewModel = new ProductListViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_db.Categories.ToList(), category, name),
                Products = items
            };           
            return View(productListViewModel);
        }
     
        #endregion

        #region List for all
       public async Task<IActionResult> ListForAll(string view, int? category, string name, int page = 1)
       {
           int pageSize = 9;
           IQueryable<Product> products = _db.Products.Include(p => p.Category);
           //фильтрация
           products = Filter(products, category, name);
           // пагинация
           var count = await products.CountAsync();
           var items = await products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

           // формируем модель представления
           var productListViewModel = new ProductListViewModel
           {
               PageViewModel = new PageViewModel(count, page, pageSize),               
               FilterViewModel = new FilterViewModel(_db.Categories.ToList(), category, name),
               Products = items
           };
           return View(productListViewModel);
       }

        #endregion

        #region Create
        [Authorize(Roles = "admin")]
        public IActionResult Create(int? category, string name)
        {
            ProductViewModel viewModel = new ProductViewModel
            {
                FilterViewModel = new FilterViewModel().FilterEditViewModel(_db.Categories.ToList(), category, name),
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {            
            if (productViewModel.Image != null)
            {
                byte[] imageData  = null;
                // считываем переданный файл в массив байтов  
                using (var binaryReader = new BinaryReader(productViewModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)productViewModel.Image.Length);
                }
                // установка массива байтов
                productViewModel.Product.Image = imageData;
            }
            productViewModel.Product.CategoryId = productViewModel.Product.Category.CategoryId;
            productViewModel.Product.Category = null;
            _db.Products.Add(productViewModel.Product);
            await _db.SaveChangesAsync();
            return RedirectToAction("ListForAdmin");
        }

        #endregion

        #region Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                {
                    ProductListViewModel viewModel = new ProductListViewModel
                    {
                        Product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id),
                        Category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == product.CategoryId)
                    };
                    return View(viewModel);
                }
            }
            return NotFound();
        }

        #endregion

        # region Edit
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id, int? category, string name)
        {
            if (id != null)
            {
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                {
                    ProductListViewModel viewModel = new ProductListViewModel
                    {
                        FilterViewModel = new FilterViewModel().FilterEditViewModel(_db.Categories.ToList(), category, name),
                        Product = product,
                        Category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == product.CategoryId)
                    };
                    return View(viewModel);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(ProductViewModel productViewModel)
        {
            if (productViewModel.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов  
                using (var binaryReader = new BinaryReader(productViewModel.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)productViewModel.Image.Length);
                }
                // установка массива байтов
                productViewModel.Product.Image = imageData;
            }
            productViewModel.Product.CategoryId = productViewModel.Product.Category.CategoryId;
            productViewModel.Product.Category = null;
            _db.Products.Update(productViewModel.Product);            
            await _db.SaveChangesAsync();
            return RedirectToAction("ListForAdmin");
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
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                {
                    ProductListViewModel viewModel = new ProductListViewModel
                    {
                        Product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id),
                        Category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == product.CategoryId)
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
                Product product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                {
                    //Product Product = new Product { Id = id.Value };
                    //_db.Entry(Product).State = EntityState.Deleted;
                    _db.Products.Remove(product);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("ListForAdmin");
                }
            }
            return NotFound();
        }

        #endregion

        #region Sort
        private IQueryable<Product> Sort(IQueryable<Product> products, SortState sortOrder)
        {
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case SortState.CategoryAsc:
                    products = products.OrderBy(s => s.Category.CategoryName);
                    break;
                case SortState.CategoryDesc:
                    products = products.OrderByDescending(s => s.Category.CategoryName);
                    break;
                case SortState.StatusAsc:
                    products = products.OrderBy(s => s.Status);
                    break;
                case SortState.StatusDesc:
                    products = products.OrderByDescending(s => s.Status);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            return products;
        }
        #endregion

        # region Filter
        private IQueryable<Product> Filter(IQueryable<Product> products, int? category, string name)
        {
            if (category != null && category != 0)
            {
                products = products.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                products = _db.Products.Where(p => p.Name.Contains(name));
            }

            return products;
        }
        #endregion

    }
}
