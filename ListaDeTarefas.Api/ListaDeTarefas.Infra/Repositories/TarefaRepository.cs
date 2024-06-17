using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Infra.Context;
using ListaDeTarefas.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDeTarefas.Infra.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationContext _context;
        public TarefaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> Post(Tarefa tarefa)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetAll()
        {
            return await _context.Set<Tarefa>().AsNoTracking().ToListAsync();                     
        }

        public async Task<Tarefa> GetById(int id)
        {
            var tarefa = await _context.Set<Tarefa>()
                        .AsNoTracking()
                        .Where(x => x.Id == id)
                        .ToListAsync();

            return tarefa.FirstOrDefault()!;
        }

        public async Task<Tarefa> Put(int id)
        {
            var tarefa = await GetById(id);

            if (tarefa != null)
            {
                tarefa.Concluida = true;
                _context.Entry(tarefa).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return tarefa;
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task Delete(int id)
        {
            var tarefa = await GetById(id);

            if (tarefa != null)
            {
                _context.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
