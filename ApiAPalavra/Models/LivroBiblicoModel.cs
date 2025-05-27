namespace ApiAPalavra.Models
{
    public class LivroBiblicoModel
    {
        public string id { get; set; }
        public string periodo { get; set; }
        public string nome { get; set; }
        public string abrev { get; set; }
        public List<List<string>> capitulos { get; set; }
    }
}
