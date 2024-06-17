using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.DTO
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string? Mensagem { get; set; }
        public bool Concluida { get; set; }
    }
}
