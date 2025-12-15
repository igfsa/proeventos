using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities;

public class RedeSocial
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string URL { get; set; }

    public int PalestranteId { get; set; }

    public Palestrante Palestrante { get; set; }
}
