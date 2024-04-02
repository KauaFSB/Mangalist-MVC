using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using mymangalist.Models;

namespace mymangalist.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Manga> mangas = GetMangas();
        List<Genero> generos = GetGeneros();
        ViewData["Generos"] = generos;
        return View(mangas);
    }

    public IActionResult Details(int id)
    {
        List<Manga> mangas = GetMangas();
        List<Genero> generos = GetGeneros();
        DetailsVM details = new() {
            Generos = generos,
            Atual = mangas.FirstOrDefault(p => p.Numero == id),
            Anterior = mangas.OrderByDescending(p => p.Numero).FirstOrDefault(p => p.Numero < id),
            Proximo = mangas.OrderBy(p => p.Numero).FirstOrDefault(p => p.Numero > id),
        };
        return View(details);
    }

    private List<Manga> GetMangas()
    {
        using (StreamReader leitor = new("Data\\mangas.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Manga>>(dados);
        }
    }

     private List<Genero> GetGeneros()
    {
        using (StreamReader leitor = new("Data\\generos.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Genero>>(dados);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
