using C067058.Domain.Interfaces.Services.SimuladorDeEmprestimo;
using C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto;

namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo
{
    public class SimuladorPriceServiceDomain : SimuladorBaseServiceDomain, ISimuladorPriceServiceDomain
    {
        readonly string Identificacao = "Tabela PRICE";

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

                var prestacaoMensal = CalcularValorDaPrestacao(valorPrincipalDoFinanciamento, taxaDeJurosMensal, periodo);
                var jurosMensal = CalcularJurosMensal(mesAnterior.SaldoDevedor, taxaDeJurosMensal);
                var amortizacaoMensal = CalcularAmortizacaoMensal(prestacaoMensal, jurosMensal);
                var saldoDevedor = CalcularSaldoDevedor(mesAnterior.SaldoDevedor, amortizacaoMensal);

                prestacoes.Adicionar(prestacaoMensal, amortizacaoMensal, jurosMensal, saldoDevedor);
            }

            var resposta = new SimuladorBase(Identificacao, prestacoes);

            return resposta;
        }

        private static double CalcularValorDaPrestacao(double p, double i, int n)
        {
            // Prestação fixa mensal: Pm = P * (i * (1 + i) ^ n) / ((1 + i) ^ n - 1)

            var calculo = p * (i * Math.Pow(1 + i, n)) / (Math.Pow(1 + i, n) - 1);

            var resposta = FormatarValorParaDecimal(calculo);

            return calculo;
        }

        private static double CalcularJurosMensal(double saldoDevedorRestante, double taxaDeJurosMensal)
        {
            var calculo = saldoDevedorRestante * taxaDeJurosMensal;

            var resposta = FormatarValorParaDecimal(calculo);

            return calculo;
        }

        private static double CalcularAmortizacaoMensal(double prestacaoMensal, double jurosMensal)
        {
            var calculo = prestacaoMensal - jurosMensal;

            var resposta = FormatarValorParaDecimal(calculo);

            return calculo;
        }

        private static double CalcularSaldoDevedor(double saldoDevedorDoMesAnterior, double amortizacaoMensal)
        {
            var calculo = saldoDevedorDoMesAnterior - amortizacaoMensal;

            var resposta = FormatarValorParaDecimal(calculo);

            return calculo;
        }
    }
}
