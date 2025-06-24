using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FitnessApp.Models;
using Microsoft.AspNetCore.Mvc;



namespace FitnessApp.Controllers
{
    public class ExercisesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var data = DP.Listeleme<Exercise>("sp_GetExercises");
            return View(data);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Id", id);

            var exercise = DP.Listeleme<Exercise>("sp_GetExerciseById", param).FirstOrDefault();
            if (exercise == null)
                return NotFound();

            return View(exercise);
        }


        [HttpPost]
        public IActionResult Add(Exercise exercise)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", exercise.UserId);
            param.Add("@ExerciseName", exercise.ExerciseName);
            param.Add("@DurationMinutes", exercise.DurationMinutes);
            param.Add("@ExerciseDate", exercise.ExerciseDate);

            DP.ExecuteReturn("sp_AddExercise", param);
            return RedirectToAction("Index");
        }
    }
}

