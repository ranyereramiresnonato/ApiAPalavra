namespace ApiAPalavra.Models
{
    public class ObjetoRetornoModel
    {
        public int StatusCode { get; set; }
        public string Resultado { get; set; } = string.Empty;
        public string Messagem { get; set; } = string.Empty ;
        public object? Data { get; set; }
    }
}
