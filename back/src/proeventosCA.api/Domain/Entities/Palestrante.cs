using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Palestrante
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string MiniCurriculo { get; set; }

    public string Tel { get; set; }

    public IEnumerable<RedeSocial> RedesSociais { get; set; }

    public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

}

