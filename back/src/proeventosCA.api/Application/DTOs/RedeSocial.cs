using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Application.DTOs;

public class RedeSocialDTO
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string URL { get; set; }

    [Required]
    public int PalestranteId { get; set; }

}
