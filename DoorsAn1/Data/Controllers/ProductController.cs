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
using System.Collections.Generic;

namespace DoorsAn1.Data.Controllers
{
    [Route("api/products")]
    public class ProductController:Controller
    {
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly IProductRepository _productRepository;
        private readonly AppDbContext _db;
        private IHostingEnvironment _environment;

        public ProductController(/*ICategoryRepository categoryRepository, IProductRepository productRepository,*/ AppDbContext context, IHostingEnvironment environment)
        {
            //_categoryRepository = categoryRepository;
            //_productRepository = productRepository;
            _db = context;
            _environment = environment;
        }

        # region Get all
        [HttpGet]
        //[Authorize(Roles = "admin")]
        public IEnumerable<Product> Get()
        {            
            return _db.Products.ToList();
        }
        #endregion

        #region Get by id
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }
        #endregion

        #region Create
        //[Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(product);
                _db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }
        #endregion      

        # region Edit
       // [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Update(product);
                _db.SaveChanges();
                return Ok(product);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product = _db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
            return Ok(product);
        }
        #endregion
    }
}
