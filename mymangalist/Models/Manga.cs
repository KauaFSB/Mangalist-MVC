namespace mymangalist.Models;

    public class Manga
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<string> Genero { get; set; } = [];
        public string Imagem { get; set; }
    }
