namespace mymangalist.Models;

public class DetailsVM
{
    public Manga Anterior {get; set; }

    public Manga Atual { get; set; }

    public Manga Proximo { get; set;}

    public List<Genero> Generos { get; set; }
}