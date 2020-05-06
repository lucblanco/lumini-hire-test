using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeScorecard.Infra.ES;
using CollegeScorecard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CollegeScorecard.Controllers
{
    public class DashboardController : Controller
    {
  
        public IActionResult Index()
        {

            return View();
        }
    }
}