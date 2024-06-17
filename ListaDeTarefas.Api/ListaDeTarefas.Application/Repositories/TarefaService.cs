using AutoMapper;
using ListaDeTarefas.Application.DTO;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Infra.Interfaces;

namespace ListaDeTarefas.Application.Repositories
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TarefaDTO>> GetAll()
        {
            var tarefas = await _tarefaRepository.GetAll();
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefas);
        }

        public async Task<TarefaDTO> Post(TarefaDTO tarefaDTO)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDTO);

            var tarefaCriada = await _tarefaRepository.Post(tarefa);
            return _mapper.Map<TarefaDTO>(tarefaCriada);
        }

        public async Task<TarefaDTO> Put(int id)
        {
            var tarefaUpdated = await _tarefaRepository.Put(id);

            return _mapper.Map<TarefaDTO>(tarefaUpdated);
        }

        public async Task Delete(int id)
        {
            await _tarefaRepository.Delete(id);
        }
    }
}

