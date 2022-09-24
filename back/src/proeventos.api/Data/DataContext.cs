// A classe Context é criada para o contexto do banco de dados, deve ser colocada com um nome representativo, no caso abaixo, "DataContext"
// Ela herda da classe DbContext

using Microsoft.EntityFrameworkCore;

namespace proeventos.api.Models;

public class DataContext : DbContext
{
    //  5 - Definir a classe de contexto 
    public DataContext(DbContextOptions<DataContext> options):base(options){}
    // Estamos criando um construtor para configurar o contexto no EntityFramework Core
    // Feita na classe base

    // 7 - Definir o mapeamento de entidades para as tabelas 
    // DbSet recebe a classe a ser mapeada, e, após é informado onde será feito o mapeamento
    public DbSet<Evento>? Eventos { get; set; }

    public DbSet<Categoria>? Categorias { get; set; }
}
