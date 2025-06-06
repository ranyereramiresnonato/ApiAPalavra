using ApiAPalavra.Models;

namespace ApiAPalavra.Services.LivroBiblicoService
{
    public interface ILivroBiblicoService
    {
        Task<ObjetoRetornoModel> BuscarTodosOsLivros();
        Task<ObjetoRetornoModel> BuscarLivroPorId(int id);
        Task<ObjetoRetornoModel> BuscarCapituloDeUmLivro(int idLivro, int numeroCapitulo);
    }
}
