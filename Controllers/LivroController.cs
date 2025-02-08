using Microsoft.AspNetCore.Mvc;
using Teste_FCS.Context;
using Teste_FCS.Models;
using Teste_FCS.Negocio.Livro;
using static Teste_FCS.Dto.LivroDTO;

namespace Teste_FCS.Controllers
{
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly Db_Context db;
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroServ, Db_Context con)
        {
            _livroService = livroServ;
            db = con;
        }

        [HttpGet]
        [Route("/TesteCon")]
        public IActionResult Teste()
        {
            var a = db.Database.CanConnect();

            return a ? Ok() : BadRequest(new { message = "não conectou ao bd"});
        }
        [HttpGet]
        [Route("Livros/ListarTodos")]
        public async Task<IActionResult> ListarLivros()
        {
            return Ok(await _livroService.BuscarTodosAsync());
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task< IActionResult> Adicionar( LivroCreateDTO model )
        {

            if (!ModelState.IsValid)
                return BadRequest(new { message = "parametro(s) inválido(s) ou não informado(s)."});

            await _livroService.AdicionarAsync( new LivroModel(model));

            return Ok();
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar()
        {
            return Ok();
        }
    }
}
