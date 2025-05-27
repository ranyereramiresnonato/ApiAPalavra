using System.Text.Json;
using ApiAPalavra.Models;

namespace ApiAPalavra.Services.LivroBiblicoService
{
    public class LivroBiblicoService : ILivroBiblicoService
    {
        private readonly IWebHostEnvironment _env;
        public LivroBiblicoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<ObjetoErroModel> BuscarTodosOsLivros()
        {
            ObjetoErroModel resultado = new ObjetoErroModel();
            try
            {
                var caminho = Path.Combine(_env.ContentRootPath, "Files", "bibliaLivre.json");
                var json = await File.ReadAllTextAsync(caminho);
                var livros = JsonSerializer.Deserialize<List<LivroBiblicoModel>>(json);

                var informacoesSimplificadas = livros.Select(l => new
                {
                    Nome = l.nome,
                    Capítulos = l.capitulos.Count(),
                    Periodo = l.periodo    

                }).ToList();

                resultado.StatusCode = 200;
                resultado.Resultado = "Sucesso";
                resultado.Messagem = "Sucesso ao realizar a busca de todos os livros";
                resultado.Data = informacoesSimplificadas;

                return resultado;
            }
            catch
            {
                resultado.StatusCode = 500;
                resultado.Resultado = "Erro";
                resultado.Messagem = "Houve um erro interno na busca dos livros bíblicos";
                resultado.Data = null;

                return resultado;
            }
        }
    }
}
