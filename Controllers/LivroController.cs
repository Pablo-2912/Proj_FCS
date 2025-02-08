using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            await _livroService.AdicionarAsync(new LivroModel(model));

            return Ok();
        }

        [HttpPut]
        [Route("Alterar")]
        public async Task<IActionResult> Alterar(LivroUpdateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Informe o id."});

            var livro = await db.Livros?.FirstOrDefaultAsync(x => x.id.Equals(model.Id));

            if(livro is null)
                return BadRequest(new { message = "Livro não encontrado."});

            var livroAtualizado = new LivroModel()
            {
                id = model.Id,
                Nome = model.Nome ?? livro.Nome,
                Autor = model.Autor ?? livro.Autor,
                Editora = model.Editora ?? livro.Editora,
                Ano = model.Ano > 0 ? model.Ano : livro.Ano,
                Resumo = model.Resumo ?? livro.Resumo
            };

            // Chama o serviço para editar
            await _livroService.EditarAsync(livroAtualizado);

            return Ok(new { message = "Dados do livro modificado." });
        }

        [HttpDelete]
        [Route("Apagar/{id}")]
        public async Task<IActionResult> Apagar(int? id)
        {
            if (id is null)
                return BadRequest(new { message = "Id fornecido é nulo." });

            await _livroService.ExcluirAsync((int)id);

            return Ok(new { Message = "Livro excluido com sucesso. " });
        }   
        
        [HttpGet]
        [Route("Search/{termo}")]
        public async Task<IActionResult> BuscarPorTituloEAutor(string termo)
        {
            if (termo is null)
                return BadRequest(new { message = "Termo fornecido é nulo ou vazio." });

            var response = await _livroService.BuscarPorNomeAutorEditoraAsync(termo);

            return Json(response);
        }
    }
}
