using C067058.Application.Dto;
using C067058.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace C067058.WebAPI.Controllers
{
    [Route("simulador-de-emprestimos-imobiliarios")]
    public class SimuladorDeEmprestimosImobiliariosController : ControllerBase
    {
        private readonly ISimuladorDeEmprestimoAppService SimuladorDeEmprestimoImobiliarioService;

        public SimuladorDeEmprestimosImobiliariosController(ISimuladorDeEmprestimoAppService simuladorDeEmprestimoImobiliarioService)
        {
            SimuladorDeEmprestimoImobiliarioService = simuladorDeEmprestimoImobiliarioService;
        }

        /* a tipagem da rota abaixo já impede valores em formatos indesejados */
        [HttpGet("{valorInformado:decimal}/{taxaInformada:decimal}/{periodoInformado:int}/resultado")]
        public IEnumerable<SimuladorBaseAppDto> Resultado(decimal valorInformado, decimal taxaInformada, int periodoInformado)
        {
            var resultado = SimuladorDeEmprestimoImobiliarioService.Calcular(valorInformado, taxaInformada, periodoInformado);

            return resultado;
        }
    }
}
