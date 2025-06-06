using System.Threading.Tasks;
using ApiAPalavra.Models;
using ApiAPalavra.Services.LivroBiblicoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAPalavra.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroBiblicoService _iLivroBiblicoService;
        public LivrosController(ILivroBiblicoService livroBiblicoService)
        {
            _iLivroBiblicoService = livroBiblicoService;
        }

        /// <summary>
        /// Busca todos os livros da bíblia
        /// </summary>
        /// <returns>Retorna todos os livros da bíblia.</returns>
        [HttpGet, Route("BuscarTodosOsLivros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LivroSimplificadoModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(List<ObjetoRetornoModel>))]
        public async Task<ActionResult> BuscarTodosOsLivros()
        {
            try
            {
                var retorno = await _iLivroBiblicoService.BuscarTodosOsLivros();

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
                resultado.Messagem = "Houve um erro interno na busca dos livros bíblicos";
                resultado.Data = null;

                return StatusCode(resultado.StatusCode, resultado);
            }
        }

        /// <summary>
        /// Busca um livro da bíblia pelo Id
        /// </summary>
        /// <param name="id">Id do livro.</param>
        /// <returns>Retorna o livro pelo Id informado.</returns>
        [HttpGet, Route("BuscarLivroPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroSimplificadoMaisCapitulosModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ObjetoRetornoModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjetoRetornoModel))]
        public async Task<IActionResult> BuscarLivroPorId(int id)
        {
            try
            {
                var retorno = await _iLivroBiblicoService.BuscarLivroPorId(id);

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
                resultado.Messagem = "Houve um erro interno na busca dos livro biblíco";
                resultado.Data = null;

                return StatusCode(resultado.StatusCode, resultado);
            }
        }

        /// <summary>
        /// Busca um capítulo completo de um livro da bíblia
        /// </summary>
        /// <param name="idLivro">Id do livro.</param>
        /// <param name="numeroCapitulo">Número do capítulo.</param>
        /// <returns>Retorna todos os versóculos do capítulo pelos parâmetros informados.</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ObjetoRetornoModel))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ObjetoRetornoModel))]
        [HttpGet, Route("BuscarCapituloDeUmLivro/{idLivro}/{numeroCapitulo}")]

        public async Task<IActionResult> BuscarCapituloDeUmLivro(int idLivro, int numeroCapitulo)
        {
            try
            {
                var retorno = await _iLivroBiblicoService.BuscarCapituloDeUmLivro(idLivro, numeroCapitulo);

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
                resultado.Messagem = "Houve um erro interno na busca do capítulo";
                resultado.Data = null;

                return StatusCode(resultado.StatusCode, resultado);
            }
        }
    }
}
