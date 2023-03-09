using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mission9_jacobac3.Models;
using Mission9_jacobac3.Models.ViewModels;

namespace Mission9_jacobac3.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        [HttpGet]
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            // make it so there are 10 books per page
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b=>b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumProjects = (bookCategory == null 
                    ? repo.Books.Count() 
                    : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    ProjectsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
            return View(x);

        }
    }
}
