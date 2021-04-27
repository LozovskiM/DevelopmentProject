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
    public class BookController : Controller
    {
        private readonly IBookService _bk;

        public BookController(IBookService bk)
        {
            _bk = bk;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.book = await _bk.GetAllAsync();
            return View();
        }
    }
}
