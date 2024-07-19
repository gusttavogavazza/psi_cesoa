namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto
{
    public class Prestacao
    {
        public int Indice { get; set; }
        public double Valor { get; set; }
        public double AmortizacaoMensal { get; set; }
        public double JurosMensal { get; set; }
        public double SaldoDevedor { get; set; }

        internal Prestacao(int indice, double valor, double amortizacaoMensal, double jurosMensal, double saldoDevedor)
        {
            Indice = indice;
            Valor = valor;
            AmortizacaoMensal = amortizacaoMensal;
            JurosMensal = jurosMensal;
            SaldoDevedor = saldoDevedor;
        }

        internal Prestacao(int indice, double saldoDevedor)
        {
            Indice = indice;
            SaldoDevedor = saldoDevedor;
        }
    }
}
