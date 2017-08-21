using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoorsAn1.Components
{
    public class CategoryMenu: ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(p=>p.CategoryName);
            return View(categories);
        }
    }
}
