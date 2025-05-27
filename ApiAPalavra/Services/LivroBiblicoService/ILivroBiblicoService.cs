using ApiAPalavra.Models;

namespace ApiAPalavra.Services.LivroBiblicoService
{
    public interface ILivroBiblicoService
    {
        Task<ObjetoErroModel> BuscarTodosOsLivros();
    }
}
