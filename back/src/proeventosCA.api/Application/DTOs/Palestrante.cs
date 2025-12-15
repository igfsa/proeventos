using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class PalestranteDTO
{
    [Required]
    public string Name { get; set; }

}

