using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Mymangalist.Models;

namespace Mymangalist.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Manga> mangas = [];
        using (StreamReader leitor = new ("Data\\mangas.json"))
        {
            string dados = leitor.ReadToEnd();
            mangas = JsonSerializer.Deserialize<List<Manga>>(dados);
        }
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
