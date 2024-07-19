namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo
{
    public class SimuladorBaseServiceDomain
    {
        internal static double FormatarValorParaDecimal(double valor)
        {
            return FormatarValorParaDecimalPadraoModelo2(valor);
        }

        internal static double FormatarValorParaDecimalPadrao(double valor)
        {
            return Math.Truncate(100 * valor) / 100;
        }

        internal static double FormatarValorParaDecimalPadraoModelo2(double valor)
        {
            return Math.Round(valor, 2);
        }

        internal static bool TemAteNDigitos(string valor, int digitosDesejados)
        {
            string[] valorInteiro = valor.Split('.');

            var resposta = valorInteiro[0].Length <= digitosDesejados;
            return resposta;
        }

        internal static bool TemDuasCasasDecimais(decimal dec)
        {
            decimal value = dec * 100;
            return value == Math.Floor(value);
        }
    }
}
