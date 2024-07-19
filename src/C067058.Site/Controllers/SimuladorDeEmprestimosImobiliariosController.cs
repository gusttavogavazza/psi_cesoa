using AutoMapper;
using C067058.Application.Interfaces;
using C067058.Site.Models.Resultado;
using Microsoft.AspNetCore.Mvc;

namespace C067058.Site.Controllers
{
    [Route("simulador-de-emprestimos-imobiliarios")]
    public class SimuladorDeEmprestimosImobiliariosController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ISimuladorDeEmprestimoAppService SimuladorDeEmprestimoImobiliarioService;

        public SimuladorDeEmprestimosImobiliariosController(ISimuladorDeEmprestimoAppService simuladorDeEmprestimoImobiliarioService, IMapper mapper)
        {
            SimuladorDeEmprestimoImobiliarioService = simuladorDeEmprestimoImobiliarioService;
            Mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        /* optei por deixar no método GET para possibilitar que o usuário também pudesse 
         * acessá-lo digitando o endereço e os parâmetros na barra de endereço, caso o 
         * Negócio quisesse uma sistemática parecida (se não fosse uma Partial View, por exemplo)
         */

        /* a tipagem da rota abaixo já impede valores em formatos indesejados */

        [HttpGet("{valorInformado:decimal}/{taxaInformada:decimal}/{periodoInformado:int}/resultado")]
        public IActionResult Resultado(decimal valorInformado, decimal taxaInformada, int periodoInformado)
        {
            var resultado = SimuladorDeEmprestimoImobiliarioService.Calcular(valorInformado, taxaInformada, periodoInformado);
            var resultadoViewModel = Mapper.Map<IList<TabelaViewModel>>(resultado);

            var viewModel = new ResultadoViewModel(resultadoViewModel, (double)valorInformado, (double)taxaInformada, periodoInformado);

            return View(viewModel);
        }
    }
}
