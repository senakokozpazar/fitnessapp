using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.Models;
using System.Data.SqlClient;
using Dapper;

namespace FitnessApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using var db = new SqlConnection(DP.connectionString);
        var exercises = db.Query<Exercise>("SELECT TOP 8 * FROM Exercises ORDER BY ExerciseDate DESC").ToList();

        return View(exercises);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

