using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
// Os dois namespaces acima são onde estão os atributos para Data Annotations, que nos permitem sobrescrever as configurações padrão na criação de tabelas 

namespace Domain.Entities;

public class PalestranteEvento
{
    public int PalestranteId { get; set; }
    public Palestrante Palestrante { get; set; }
    public int EventoId { get; set; }
    public Evento Evento { get; set; }
}
