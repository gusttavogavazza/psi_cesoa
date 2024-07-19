using C067058.Application.Dto;
using C067058.Application.Interfaces;
using C067058.Domain.Interfaces.Services.SimuladorDeEmprestimo;
using C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto;

namespace C067058.Application.Services.SimuladorDeEmprestimo
{
    public class SimuladorDeEmprestimoAppService : ISimuladorDeEmprestimoAppService
    {
        private readonly ISimuladorSacServiceDomain SimuladorSacServiceDomain;
        private readonly ISimuladorPriceServiceDomain SimuladorPriceServiceDomain;

        public SimuladorDeEmprestimoAppService(
            ISimuladorSacServiceDomain simuladorSacServiceDomain,
            ISimuladorPriceServiceDomain simuladorPriceServiceDomain
            )
        {
            SimuladorSacServiceDomain = simuladorSacServiceDomain;
            SimuladorPriceServiceDomain = simuladorPriceServiceDomain;
        }

        public IList<SimuladorBaseAppDto> Calcular(decimal valor, decimal taxa, int periodo)
        {
            var resultado = new List<SimuladorBase>();

            var doubleValor = (double)valor;
            var doubleTaxaEmPercentual= (double)(taxa / 100);
            var doublePeriodo = (double)periodo;

            SimuladorBase? simulador = null;

            simulador = SimuladorPriceServiceDomain.Calcular(doubleValor, doubleTaxaEmPercentual, periodo);
            if (simulador != null) resultado.Add(simulador);

            simulador = SimuladorSacServiceDomain.Calcular(doubleValor, doubleTaxaEmPercentual, periodo);
            if (simulador != null) resultado.Add(simulador);

            return Map(resultado);
        }

        private IList<SimuladorBaseAppDto> Map(IList<SimuladorBase> source)
        {
            var resposta = new List<SimuladorBaseAppDto>();

            foreach (var item in source)
                resposta.Add(Map(item));

            return resposta;

        }

        private SimuladorBaseAppDto Map(SimuladorBase item)
        {
            return new SimuladorBaseAppDto()
            {
                Identificacao = item.Identificacao,
                Prestacoes = Map(item.Prestacoes),
                TotalAmortizacaoMensal = item.TotalAmortizacaoMensal,
                TotalJurosMensal = item.TotalJurosMensal,
                Total = item.Total,
            };
        }

        private IList<PrestacaoAppDto> Map(IList<Prestacao> source)
        {
            var resposta = new List<PrestacaoAppDto>();

            foreach (var item in source)
                resposta.Add(Map(item));

            return resposta;
        }

        private PrestacaoAppDto Map(Prestacao prestacao)
        {
            return new PrestacaoAppDto()
            {
                AmortizacaoMensal = prestacao.AmortizacaoMensal,
                Indice = prestacao.Indice,
                JurosMensal = prestacao.JurosMensal,
                Valor = prestacao.Valor,
                SaldoDevedor = prestacao.SaldoDevedor
            };
        }
    }
}
