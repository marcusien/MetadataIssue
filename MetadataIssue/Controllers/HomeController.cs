using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MetadataIssue.Models;
using MetadataIssue.ViewModels;

namespace MetadataIssue.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ChildViewModel();
            return View(viewModel);
        }

       
    }
}
