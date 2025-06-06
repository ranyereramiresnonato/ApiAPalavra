using ApiAPalavra.Models;
using ApiAPalavra.Services.VersiculoBiblicoService;
using Microsoft.AspNetCore.Mvc;

namespace ApiAPalavra.Controllers
{
    public class VersiculosController : Controller
    {
        private readonly IVersiculoBiblicoService _versiculoBiblicoService;
        public VersiculosController(IVersiculoBiblicoService versiculoBiblicoService)
        {
            _versiculoBiblicoService = versiculoBiblicoService;
        }

        [HttpGet, Route("BuscarVersiculoBiblico/{idLivro}/{numeroCapitulo}/{numeroVersiculo}")]

        public async Task<IActionResult> BuscarVersiculoBiblico(int idLivro, int numeroCapitulo, int numeroVersiculo)
        {
            try
            {
                var retorno = await _versiculoBiblicoService.BuscarVersiculoBiblico(idLivro, numeroCapitulo, numeroVersiculo);

                if (retorno.StatusCode == 200)
                {
                    return Ok(retorno.Data);
                }
                else
                {
                    return StatusCode(retorno.StatusCode, retorno);
                }
            }
            catch
            {
                ObjetoRetornoModel resultado = new ObjetoRetornoModel();
                resultado.StatusCode = 500;
                resultado.Resultado = "Erro";
                resultado.Messagem = "Houve um erro interno na busca do versículo";
                resultado.Data = null;

                return StatusCode(resultado.StatusCode, resultado);
            }
        }
    }
}
