using System.Collections.ObjectModel;

namespace C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto
{
    public class SimuladorBase
    {
        public string Identificacao { get; private set; }

        internal Prestacoes _Prestacoes { get; set; }

        //public ReadOnlyCollection<Prestacao> Prestacoes => _Prestacoes.ListaDePrestacoes;

        public IList<Prestacao> Prestacoes => _Prestacoes.ListaDePrestacoes;

        public double Total => Prestacoes.Sum(item => item.Valor);

        public double TotalAmortizacaoMensal => Prestacoes.Sum(item => item.AmortizacaoMensal);

        public double TotalJurosMensal => Prestacoes.Sum(item => item.JurosMensal);

        public SimuladorBase(string identificacao, Prestacoes prestacoes)
        {
            Identificacao = identificacao;
            _Prestacoes = prestacoes;
        }
    }
}
