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

        /// <summary>
        /// Busca um versículo bíblico e o retorna
        /// </summary>
        /// <param name="idLivro">Id do livro.</param>
        /// <param name="numeroCapitulo">Número do capítulo.</param>
        /// <param name="numeroVersiculo">Número do versículo.</param>
        /// <returns>Retorna o versículo correspondente aos parâmetros.</returns>
        [HttpGet, Route("BuscarVersiculoBiblico/{idLivro}/{numeroCapitulo}/{numeroVersiculo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ObjetoRetornoModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjetoRetornoModel))]
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
