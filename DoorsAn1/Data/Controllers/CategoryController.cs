//using DoorsAn1.Data.interfaces;
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
    [Route("api/categories")]
    public class CategoryController: Controller
    {
        //private readonly ICategoryRepository _categoryRepository;       
        private readonly AppDbContext _db;
        private IHostingEnvironment _environment;

        public CategoryController(/*ICategoryRepository categoryRepository,*/ AppDbContext context, IHostingEnvironment environment)
        {
            //_categoryRepository = categoryRepository;            
            _db = context;
            _environment = environment;
        }

        #region Create
        //[Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create([FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Edit
        //[Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                _db.Update(category);
                _db.SaveChanges();
                return Ok(category);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        //[ActionName("Delete")]
        //[Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {
            Category category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            return Ok(category);
        } 
        #endregion 
    }
}
