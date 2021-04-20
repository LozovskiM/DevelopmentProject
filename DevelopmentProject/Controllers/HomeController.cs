using DevelopmentProject.DB.Models;
using DevelopmentProject.Interfaces;
using DevelopmentProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentProject.Controllers
{
    public class HomeController : Controller
    {
        public readonly IBookService _bk;

        public HomeController(IBookService bk)
        {
            _bk = bk;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> books = await _bk.GetAllAsync();
            ViewBag.book = books;
            return View();
        }
    }
}
