using AutoMapper;
using ListaDeTarefas.Api.ViewModels;
using ListaDeTarefas.Application.DTO;
using ListaDeTarefas.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Api.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly IMapper _mapper;

        public TarefaController(IMapper mapper, ITarefaService tarefaService)
        {
            _mapper = mapper;
            _tarefaService = tarefaService;
        }

        [HttpPost("/api/tarefas/post")]
        public async Task<IActionResult> Post([FromBody] CriarTarefaViewModel tarefaViewModel)
        {
            try
            {
                var tarefaDTO = _mapper.Map<TarefaDTO>(tarefaViewModel);

                var tarefaCriada = await _tarefaService.Post(tarefaDTO);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Tarefa criada com sucesso!",
                    Successo = true,
                    Resultado = tarefaCriada
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao processar a requisição." });
            }
        }

        [HttpPut("api/tarefas/put")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var tarefaAlterada = await _tarefaService.Put(id);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Tarefa concluída com sucesso",
                    Successo = true,
                    Resultado = tarefaAlterada
                });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao processar a requisição." });
            }
        }

        [HttpDelete("api/tarefas/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _tarefaService.Delete(id);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Tarefa removida com sucesso",
                    Successo = true,
                    Resultado = null
                });
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao processar a requisição." });
            }
        }

        [HttpGet("api/tarefas/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Tarefas = await _tarefaService.GetAll();

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Tarefas encontradas com sucesso",
                    Successo = true,
                    Resultado = Tarefas
                });
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Ocorreu um erro ao processar a requisição." });
            }
        }
    }
}
