//   2 - Criar o modelo de entidades 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
// Os dois namespaces acima são onde estão os atributos para Data Annotations, que nos permitem sobrescrever as configurações padrão na criação de tabelas 

namespace proeventos.api.Models;

public class Evento
{
    [Key]
    public int EventoId { get; set;}

    [Required]
    [StringLength(500, ErrorMessage = "Nome muito longo")]
    public string? Local { get; set;}

    [Required]
    [StringLength(11)]
    //Alterar o formato para data 
    //https://stackoverflow.com/questions/5252979/assign-format-of-datetime-with-data-annotations
    public string? DataEvento { get; set; }

    [Required]
    [StringLength(200)]
    public string? Tema { get; set; }

    [Required]
    public int QtdPessoas { get; set; }
    
    [Required]
    [StringLength(4)]
    public string? Lote { get; set; }

    [Required]
    [Column(TypeName ="decimal(10,2)")]
    public decimal? Valor { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImagemURL { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    public Categoria? Categoria { get; set; }
}
