using System.Text.Json;
using ApiAPalavra.Models;

namespace ApiAPalavra.Services.VersiculoBiblicoService
{
    public class VersiculoBiblicoService : IVersiculoBiblicoService
    {
        private readonly IWebHostEnvironment _env;
        public VersiculoBiblicoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<ObjetoRetornoModel> BuscarVersiculoBiblico(int idLivro, int numeroCapitulo, int numeroVersiculo)
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

                    if (numeroVersiculo > capituloEscolhido.Count() || numeroVersiculo <= 0)
                    {
                        resultado.StatusCode = 404;
                        resultado.Resultado = "Erro";
                        resultado.Messagem = "Versículo inválido para o capítulo";
                        resultado.Data = null;

                        return resultado;
                    }

                    resultado.StatusCode = 200;
                    resultado.Resultado = "Sucesso";
                    resultado.Messagem = "Sucesso ao realizar a busca dos versículos";
                    resultado.Data = capituloEscolhido[numeroVersiculo - 1];

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
                resultado.Messagem = "Houve um erro interno ao buscar o versículo bíblico";
                resultado.Data = null;

                return resultado;
            }
        }
    }
}
