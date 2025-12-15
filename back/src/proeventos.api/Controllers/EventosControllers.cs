// observações para realização de consultas: 
// Nunca se deve retornar todos os registros em uma consulta
// nunca se deve retornar objetos realcionados sem um filtro
// realizar esses processos pode gerar uma sobrecarga no sistema

using Microsoft.AspNetCore.Mvc;
using proeventos.api.Models;
using Microsoft.EntityFrameworkCore;

namespace proeventos.api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;
    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ActionName("GetAll")]
    public ActionResult<IEnumerable<Evento>> Get()
    {
        try
        { 
            var eventos = _context.Eventos_a.Take(500).AsNoTracking().Include(c => c.Categoria).Where(e => e.EventoId <= 500).ToList();
            // para pesquisas simples, métodos gets, não se faz necessário o rastreamento. Usar AsNoTracking nos permite tornar o programa mais leve pois remove esse recurso
            if (eventos is null)
            {
                return NotFound();
            }
            return eventos;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpGet("{id:int}", Name = "ObterEventoId")]
    [ActionName("GetId")]
    public ActionResult<Evento> Get(int id)
    {
        try
        { 
            var evento = _context.Eventos_a.AsNoTracking().Include(c => c.Categoria).FirstOrDefault(evento => evento.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpGet("{tema}", Name = "ObterEventoTema")]
    [ActionName("GetTema")]
    public ActionResult<Evento> Get(string tema)
    {
        try  
        { 
            var evento = _context.Eventos_a.Take(500).AsNoTracking().Include(c => c.Categoria).FirstOrDefault(evento => evento.Tema == tema);
            if (evento == null)
            {
                return NotFound();
            }
            return evento;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpPost]
    [ActionName("Post")]
    public ActionResult Post(Evento evento)
    {
        try
        { 
            if (evento is null)
            {
                return BadRequest();
            }

            _context.Eventos_a.Add(evento);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterEventoId", new { id = evento.EventoId }, evento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }

    [HttpPut("{id:int}")]
    [ActionName("Put")]
    public ActionResult Put(int id, Evento evento)
    {
        try
        { 
        if (id != evento.EventoId)
            {
                return BadRequest();
            }

            _context.Entry(evento).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(evento);
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
            var evento = _context.Eventos_a.FirstOrDefault(evento => evento.EventoId == id);
            if (evento is null)
            {
                return NotFound();
            }
            _context.Eventos_a.Remove(evento);
            _context.SaveChanges();
            return Ok(evento);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                            "Ocorreu um problema ao tratar sua solicitação...");
        }
    }
}




