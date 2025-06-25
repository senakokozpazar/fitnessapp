using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessApp.Controllers
{
    public class ExerciseSummaryController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var summary = DP.Listeleme<ExerciseSummary>("sp_GetExerciseSummary").FirstOrDefault();
            ViewBag.Summary = summary;

            var exercises = DP.Listeleme<Exercise>("sp_GetExercises");
            return View(exercises);
        }

    }
}

