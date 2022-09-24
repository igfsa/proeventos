using Microsoft.AspNetCore.Mvc;
using proeventos.api.Models;
using Microsoft.EntityFrameworkCore;

namespace proeventos.api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CategoriasController : ControllerBase
{
    private readonly DataContext _context;
    public CategoriasController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ActionName("GetAll")]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try
        {
            var categorias = _context.Categorias.Take(500).AsNoTracking().Include(e => e.Eventos).Where(c => c.CategoriaId <= 500).ToList();
            if (categorias is null)
            {
                return NotFound();
            }
            return categorias;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpGet("{id:int}", Name = "ObterCategoriaId")]
    [ActionName("GetId")]
    public ActionResult<Categoria> Get(int id)
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(categoria => categoria.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }


    [HttpGet("{nome}", Name = "ObterCategoriaNome")]
    [ActionName("GetNome")]
    public ActionResult<Categoria> Get(string nome)
    {
        try
        {
            var categoria = _context.Categorias.Take(500).AsNoTracking().FirstOrDefault(categoria => categoria.Nome == nome);
            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpPost]
    [ActionName("Post")]
    public ActionResult Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();
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
    public ActionResult Put(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
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
    public ActionResult Delete(int id)
    {
        try
        {
            var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.CategoriaId == id);
            if (categoria is null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }
}



