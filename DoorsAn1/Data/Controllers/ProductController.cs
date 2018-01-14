using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using DoorsAn1.Data.interfaces;
using DoorsAn1.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;

namespace DoorsAn1.Data.Controllers
{
    [Route("api/[controller]")]
    public class ProductController:Controller
    {
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly IProductRepository _productRepository;
        private readonly AppDbContext _db;
        //private IHostingEnvironment _environment;

        public ProductController(/*ICategoryRepository categoryRepository, IProductRepository productRepository,*/ AppDbContext context/*, IHostingEnvironment environment*/)
        {
            //_categoryRepository = categoryRepository;
            //_productRepository = productRepository;
            _db = context;
            //_environment = environment;
        }

        # region List products
        [HttpGet]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }
        #endregion

        #region Get product by id
        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            return Ok(product);
        }     
        #endregion

        //#region Create
        //[Authorize(Roles = "admin")]
        //public IActionResult Create(int? category, string name)
        //{
           
        //    return View(viewModel);
        //}

        //[HttpPost]
        //[Authorize(Roles = "admin")]
        //public async Task<IActionResult> Create(ProductViewModel productViewModel)
        //{            
        //    if (productViewModel.Image != null)
        //    {
        //        byte[] imageData  = null;
        //        // считываем переданный файл в массив байтов  
        //        using (var binaryReader = new BinaryReader(productViewModel.Image.OpenReadStream()))
        //        {
        //            imageData = binaryReader.ReadBytes((int)productViewModel.Image.Length);
        //        }
        //        // установка массива байтов
        //        productViewModel.Product.Image = imageData;
        //    }
        //    productViewModel.Product.CategoryId = productViewModel.Product.Category.CategoryId;
        //    productViewModel.Product.Category = null;
        //    _db.Products.Add(productViewModel.Product);
        //    await _db.SaveChangesAsync();
        //    return RedirectToAction("ListForAdmin");
        //}

        //#endregion

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
                        //Category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == product.CategoryId)
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
                        //FilterViewModel = new FilterViewModel().FilterEditViewModel(_db.Categories.ToList(), category, name),
                        Product = product,
                        //Category = await _db.Categories.FirstOrDefaultAsync(p => p.CategoryId == product.CategoryId)
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
            //productViewModel.Product.CategoryId = productViewModel.Product.Category.CategoryId;
            //productViewModel.Product.Category = null;
            _db.Products.Update(productViewModel.Product);            
            await _db.SaveChangesAsync();
            return RedirectToAction("ListForAdmin");
        }

        #endregion

        #region Delete
        /*[HttpGet]
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
                    //ViewBag.id = id;
                    return PartialView("Partial/Product/Delete");
                }
            }
            return NotFound();
        }*/

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

        //#region Sort
        //private IQueryable<Product> Sort(IQueryable<Product> products, SortState sortOrder)
        //{
        //    switch (sortOrder)
        //    {
        //        case SortState.NameDesc:
        //            products = products.OrderByDescending(s => s.Name);
        //            break;
        //        case SortState.CategoryAsc:
        //            products = products.OrderBy(s => s.Category.CategoryName);
        //            break;
        //        case SortState.CategoryDesc:
        //            products = products.OrderByDescending(s => s.Category.CategoryName);
        //            break;
        //        case SortState.StatusAsc:
        //            products = products.OrderBy(s => s.Status);
        //            break;
        //        case SortState.StatusDesc:
        //            products = products.OrderByDescending(s => s.Status);
        //            break;
        //        default:
        //            products = products.OrderBy(s => s.Name);
        //            break;
        //    }
        //    return products;
        //}
        //#endregion

        //# region Filter
        //private IQueryable<Product> Filter(IQueryable<Product> products, int? category, string name)
        //{
        //    if (category != null && category != 0)
        //    {
        //        products = products.Where(p => p.CategoryId == category);
        //    }
        //    if (!String.IsNullOrEmpty(name))
        //    {
        //        products = _db.Products.Where(p => p.Name.Contains(name));
        //    }

        //    if (products.Count() == 0) {

        //        ModelState.AddModelError("CustomError", "Ничего не найдено!");
        //    }

        //    return products;
        //}
        //#endregion

    }
}
