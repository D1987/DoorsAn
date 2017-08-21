using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorsAn1.Data.interfaces;
using DoorsAn1.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DoorsAn1.Data.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel();
            return View(homeViewModel);
        }
    }
}
