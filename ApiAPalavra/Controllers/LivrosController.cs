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

        [HttpGet, Route("BuscarTodosOsLivros")]
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

        [HttpGet, Route("BuscarLivroPorId/{id}")]
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
