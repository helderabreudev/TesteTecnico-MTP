using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Api.ViewModels
{
    public class ResultadoViewModel
    {
        public string? Mensagem { get; set; }
        public bool Successo { get; set; }
        public dynamic? Resultado { get; set; }
    }
}
