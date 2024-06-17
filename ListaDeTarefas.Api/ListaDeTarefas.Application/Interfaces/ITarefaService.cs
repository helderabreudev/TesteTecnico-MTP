using ListaDeTarefas.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<TarefaDTO> Post(TarefaDTO tarefa);
        Task<IEnumerable<TarefaDTO>> GetAll();
        Task<TarefaDTO> Put(int id);
        Task Delete(int id);
    }
}
