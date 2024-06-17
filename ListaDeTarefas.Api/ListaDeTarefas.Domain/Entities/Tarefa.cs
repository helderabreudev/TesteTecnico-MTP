using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Domain.Entities
{
    public  class Tarefa
    {
        public Tarefa(int id, string mensagem, bool concluida)
        {
            Id = id;
            Mensagem = mensagem;
            Concluida = concluida;
        }

        public int Id { get; set; }
        public string Mensagem { get; set; }
        public bool Concluida { get; set; }
    }
}
