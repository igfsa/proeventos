//   2 - Criar o modelo de entidades 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;
// Os dois namespaces acima são onde estão os atributos para Data Annotations, que nos permitem sobrescrever as configurações padrão na criação de tabelas 

namespace Application.DTOs;

public class EventoDTO
{
    [Required]
    [StringLength(500, ErrorMessage = "Nome muito longo")]
    public string? Local { get; set; }

    [Required]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
    public DateTime? DataEvento { get; set; }

    [Required]
    [StringLength(200)]
    public string? Tema { get; set; }

    [Required]
    public int QtdPessoas { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImagemURL { get; set; }

    [Required]
    public IEnumerable<Lote> Lote { get; set; }

    [Required]
    public int CategoriaId { get; set; }

}
