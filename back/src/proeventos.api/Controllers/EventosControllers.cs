using Microsoft.AspNetCore.Mvc;
using proeventos.api.Models;

namespace proeventos.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
 /*   public IEnumerable<Evento> _eventos = new Evento[] 
    {
        new Evento
        {
            EventoId = 1,
            Tema = "Tema1",
            Local = "Cidade1",
            Lote = "1º",
            QtdPessoas = 100,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
        },
        new Evento
        {
            EventoId = 2,
            Tema = "Tema2",
            Local = "Cidade2",
            Lote = "1º",
            QtdPessoas = 100,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
        }

    };*/

    private readonly DataContext _context;
    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> Get(int id)
    {
        return _context.Eventos.Where(evento => evento.EventoId == id);
    }


}




