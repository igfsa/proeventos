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
    [StringLength(500)]
    public string? Local { get; set;}

    [Required]
    [StringLength(11)]
    public string? DataEvento { get; set; }

    [Required]
    [StringLength(200)]
    public string? Tema { get; set; }

    [Required]
    [StringLength(10)]
    public int QtdPessoas { get; set; }
    
    [Required]
    [StringLength(4)]
    public string? Lote { get; set; }
    
    [Required]
    [StringLength(300)]
    public string? ImagemURL { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    [Required]
    public Categoria Categoria { get; set; }
}
