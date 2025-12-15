//   2 - Criar o modelo de entidades 

using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
// Os dois namespaces acima são onde estão os atributos para Data Annotations, que nos permitem sobrescrever as configurações padrão na criação de tabelas 


namespace Application.DTOs;

[Table("Categorias")]
// No caso, o uso de table está sendo redundante, pois o mapeamento já está definido no arquivo de contexto

public class CategoriaDTO
{
    [Key]
    // Key, por estarmos usando Id, está sendo redundante
    public int Id { get; set; }
    // Ao usarmos Id, a propriedade é reconhecida como chave primaria

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }
}
