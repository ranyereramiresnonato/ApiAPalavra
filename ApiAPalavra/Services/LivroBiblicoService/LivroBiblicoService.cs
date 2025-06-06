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

        public async Task<ObjetoRetornoModel> BuscarTodosOsLivros()
        {
            ObjetoRetornoModel resultado = new ObjetoRetornoModel();
            try
            {
                var caminho = Path.Combine(_env.ContentRootPath, "Files", "bibliaLivre.json");
                var json = await File.ReadAllTextAsync(caminho);
                var livros = JsonSerializer.Deserialize<List<LivroBiblicoModel>>(json);

                var informacoesSimplificadas = livros.Select(l => new LivroSimplificadoModel
                {
                    id = int.Parse(l.id),
                    nome = l.nome,
                    quantidadeDeCapitulos = l.capitulos.Count(),
                    periodo = l.periodo    

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

        public async Task<ObjetoRetornoModel> BuscarLivroPorId(int id)
        {
            ObjetoRetornoModel resultado = new ObjetoRetornoModel();
            try
            {
                var caminho = Path.Combine(_env.ContentRootPath, "Files", "bibliaLivre.json");
                var json = await File.ReadAllTextAsync(caminho);
                var livros = JsonSerializer.Deserialize<List<LivroBiblicoModel>>(json);
                var livroBiblico = livros.Find(x => x.id == id.ToString());

                if (livroBiblico != null)
                {
                    var livroAdaptado = new LivroSimplificadoMaisCapitulosModel
                    {
                        id = int.Parse(livroBiblico.id),
                        nome = livroBiblico.nome,
                        quantidadeDeCapitulos = livroBiblico.capitulos.Count(),
                        periodo = livroBiblico.periodo,
                        capitulos = livroBiblico.capitulos,
                        
                    };
                    resultado.StatusCode = 200;
                    resultado.Resultado = "Sucesso";
                    resultado.Messagem = "Sucesso ao realizar a busca do livro bíblico";
                    resultado.Data = livroAdaptado;

                    return resultado;
                }
                else
                {
                    resultado.StatusCode = 404;
                    resultado.Resultado = "Erro";
                    resultado.Messagem = "Livro bíblico não encontrado para o id";
                    resultado.Data = null;

                    return resultado;
                }
            }
            catch
            {
                resultado.StatusCode = 500;
                resultado.Resultado = "Erro";
                resultado.Messagem = "Houve um erro interno na busca dos livro bíblico";
                resultado.Data = null;

                return resultado;
            }
        }

        public async Task<ObjetoRetornoModel> BuscarCapituloDeUmLivro(int idLivro, int numeroCapitulo)
        {
            ObjetoRetornoModel resultado = new ObjetoRetornoModel();
            try
            {
                var caminho = Path.Combine(_env.ContentRootPath, "Files", "bibliaLivre.json");
                var json = await File.ReadAllTextAsync(caminho);
                var livros = JsonSerializer.Deserialize<List<LivroBiblicoModel>>(json);
                var livroBiblico = livros.Find(x => x.id == idLivro.ToString());

                if (livroBiblico != null)
                {
                    if (numeroCapitulo > livroBiblico.capitulos.Count() || numeroCapitulo <= 0)
                    {
                        resultado.StatusCode = 404;
                        resultado.Resultado = "Erro";
                        resultado.Messagem = "Capítulo inválido para o livro escolhido";
                        resultado.Data = null;

                        return resultado;
                    }

                    var capituloEscolhido = livroBiblico.capitulos[numeroCapitulo - 1];
                    resultado.StatusCode = 200;
                    resultado.Resultado = "Sucesso";
                    resultado.Messagem = "Sucesso ao realizar a busca dos versículos";
                    resultado.Data = capituloEscolhido;

                    return resultado;
                }
                else
                {
                    resultado.StatusCode = 404;
                    resultado.Resultado = "Erro";
                    resultado.Messagem = "Livro bíblico não encontrado para o id";
                    resultado.Data = null;

                    return resultado;
                }
            }
            catch
            {
                resultado.StatusCode = 500;
                resultado.Resultado = "Erro";
                resultado.Messagem = "Houve um erro interno na busca dos versículos";
                resultado.Data = null;

                return resultado;
            }
        }
    }
}
