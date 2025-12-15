//   2 - Criar o modelo de entidades 
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
// Os dois namespaces acima s�o onde est�o os atributos para Data Annotations, que nos permitem sobrescrever as configura��es padr�o na cria��o de tabelas 

namespace Domain.Entities;

public class Evento
{
    public int Id { get; set; }

    public string? Local { get; set; }

    public DateTime? DataEvento { get; set; }

    public string? Tema { get; set; }

    public int QtdPessoas { get; set; }

    public string? ImagemURL { get; set; }

    public string Telefone { get; set; }

    public IEnumerable<RedeSocial> RedeSocial { get; set; }

    public IEnumerable<Lote> Lote { get; set; }

    public int CategoriaId { get; set; }

    public IEnumerable<Categoria> Categoria { get; set; }

    public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

}
