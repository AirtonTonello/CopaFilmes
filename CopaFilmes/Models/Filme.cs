using System.Collections.Generic;

namespace CopaFilmes.Models
{
    public class Filme
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public float Nota { get; set; }
        public IList<string> FilmesSelecionados { get; set; }
        public string Campeao { get; set; }
        public string CampeaoNota { get; set; }
        public string Vice { get; set; }
        public string ViceNota { get; set; }
    }
}