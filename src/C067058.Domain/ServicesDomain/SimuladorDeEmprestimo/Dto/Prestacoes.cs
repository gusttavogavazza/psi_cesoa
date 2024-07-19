using System.Collections.ObjectModel;

namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto
{
    public class Prestacoes
    {
        public IList<Prestacao> ListaDePrestacoes { get; set; } = new List<Prestacao>();

        //public ReadOnlyCollection<Prestacao> ListaDePrestacoes => _ListaDePrestacoes.AsReadOnly();

        internal Prestacoes(double saldoDevedor)
        {
            AdicionarPrestacaoZero(saldoDevedor);
        }

        public void Adicionar(double valor, double amortizacaoMensal, double jurosMensal, double saldoDevedor)
        {
            var novaPrestacao = new Prestacao(
                ListaDePrestacoes.Count,
                valor,
                amortizacaoMensal,
                jurosMensal,
                saldoDevedor);

            Adicionar(novaPrestacao);
        }

        protected void AdicionarPrestacaoZero(double saldoDevedor)
        {
            var novaPrestacao = new Prestacao(ListaDePrestacoes.Count, saldoDevedor);
            Adicionar(novaPrestacao);
        }

        protected void Adicionar(Prestacao prestacao)
        {
            ListaDePrestacoes.Add(prestacao);
        }
    }
}
