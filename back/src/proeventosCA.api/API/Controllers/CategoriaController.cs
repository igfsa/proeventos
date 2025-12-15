using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.GetCategorias();
            if (categorias is null)
            {
                return NotFound();
            }
            return Ok(categorias);
        }

        [HttpGet("{id:int}", Name = "ObterCategoriaId")]
        [ActionName("GetId")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {

            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);

        }


        [HttpGet("{nome}", Name = "ObterCategoriaNome")]
        [ActionName("GetNome")]
        public async Task<ActionResult<CategoriaDTO>> Get(string nome)
        {

            var categoria = await _categoriaService.(categoria => categoria.Nome == nome);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);

        }

        [HttpPost]
        [ActionName("Post")]
        public async Task<ActionResult<CategoriaDTO>> Post(Categoria categoria)
        {
            try
            {
                if (categoria is null)
                {
                    return BadRequest();
                }

                _categoriaService.Categorias.Add(categoria);
                _categoriaService.SaveChanges();
                return new CreatedAtRouteResult("ObterCategoriaId", new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                "Ocorreu um problema ao tratar sua solicitação...");
            }
        }

        [HttpPut("{id:int}")]
        [ActionName("Put")]
        public async Task<ActionResult> Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                {
                    return BadRequest();
                }

                _categoriaService.Entry(categoria).State = EntityState.Modified;
                _categoriaService.SaveChanges();
                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                "Ocorreu um problema ao tratar sua solicitação...");
            }
        }

        [HttpDelete("{id:int}")]
        [ActionName("Delete")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            try
            {
                var categoria = _categoriaService.Categorias.FirstOrDefault(categoria => categoria.CategoriaId == id);
                if (categoria is null)
                {
                    return NotFound();
                }
                _categoriaService.Categorias.Remove(categoria);
                _categoriaService.SaveChanges();
                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                                "Ocorreu um problema ao tratar sua solicitação...");
            }
        }
    }

}
