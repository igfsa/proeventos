using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Lote
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal? Valor { get; set; }

    public DateTime? DataInicio { get; set; }

    public DateTime? DataFim { get; set; }

    public Evento Evento { get; set; }

    public int PalestranteId { get; set; }

    public IEnumerable<Palestrante> Palestrantes { get; set; }
}

