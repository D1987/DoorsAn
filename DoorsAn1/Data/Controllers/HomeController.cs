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
        public ViewResult Index()
        {           
            return View();
        }
    }
}
