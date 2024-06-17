using ListaDeTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Infra.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Tarefa> Post(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> GetAll();
        Task<Tarefa> GetById(int id);
        Task<Tarefa> Put(int id);
        Task Delete(int id);
    }
}
