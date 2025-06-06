using ApiAPalavra.Models;

namespace ApiAPalavra.Services.VersiculoBiblicoService
{
    public interface IVersiculoBiblicoService
    {
        Task<ObjetoRetornoModel> BuscarVersiculoBiblico(int idLivro, int numeroCapitulo, int numeroVersiculo);
    }
}
