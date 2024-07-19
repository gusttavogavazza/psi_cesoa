using C067058.Domain.Interfaces.Services.SimuladorDeEmprestimo;
using C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto;

namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo
{
    public class SimuladorSacServiceDomain : SimuladorBaseServiceDomain, ISimuladorSacServiceDomain
    {
        readonly string Identificacao = "Tabela SAC";

        public SimuladorBase Calcular(double valorPrincipalDoFinanciamento, double taxaDeJurosMensal, int periodo)
        {
            var entradasValidas = true
                && TemAteNDigitos(valorPrincipalDoFinanciamento.ToString(), 9)
                && TemDuasCasasDecimais((decimal)taxaDeJurosMensal)
                && TemDuasCasasDecimais(periodo);

            if (!entradasValidas) return null;

            var prestacoes = new Prestacoes(valorPrincipalDoFinanciamento);

            for (int i = 1; i <= periodo; i++)
            {
                var mesAnterior = prestacoes.ListaDePrestacoes.LastOrDefault();

                var amortizacaoMensal = CalcularAmortizacaoMensal(mesAnterior.SaldoDevedor, periodo - i + 1);
                var prestacaoMensal = CalcularValorDaPrestacao(valorPrincipalDoFinanciamento, amortizacaoMensal, taxaDeJurosMensal, periodo, i);
                var jurosMensal = CalcularJurosMensal(mesAnterior.SaldoDevedor, taxaDeJurosMensal);
                var saldoDevedor = CalcularSaldoDevedor(mesAnterior.SaldoDevedor, amortizacaoMensal);

                prestacoes.Adicionar(prestacaoMensal, amortizacaoMensal, jurosMensal, saldoDevedor);
            }

            var resposta = new SimuladorBase(Identificacao, prestacoes);

            return resposta;
        }

        private static double CalcularValorDaPrestacao(double valorPrincipalDoFinanciamento, double amortizacao, double taxaDeJurosMensalEmPercentual, int periodo, int indiceDaPrestacao)
        {
            //A + (P - (m-1) * A) * i
            var calculo = amortizacao + (valorPrincipalDoFinanciamento - (indiceDaPrestacao - 1) * amortizacao) * taxaDeJurosMensalEmPercentual;

            var resposta = FormatarValorParaDecimal(calculo);

            return resposta;
        }

        private static double CalcularJurosMensal(double saldoDevedorRestante, double taxaDeJurosMensal)
        {
            var calculo = saldoDevedorRestante * taxaDeJurosMensal;

            var resposta = FormatarValorParaDecimal(calculo);

            return resposta;
        }

        private static double CalcularAmortizacaoMensal(double saldoDevedorRestante, double quantidadeDeMesesRestantes)
        {
            var calculo = saldoDevedorRestante / quantidadeDeMesesRestantes;

            var resposta = FormatarValorParaDecimal(calculo);

            return resposta;
        }

        private static double CalcularSaldoDevedor(double saldoDevedorDoMesAnterior, double amortizacaoMensal)
        {
            var calculo = saldoDevedorDoMesAnterior - amortizacaoMensal;

            var resposta = FormatarValorParaDecimal(calculo);

            return resposta;
        }
    }
}
