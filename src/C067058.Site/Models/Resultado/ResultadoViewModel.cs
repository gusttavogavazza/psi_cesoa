namespace C067058.Site.Models.Resultado
{
    public class ResultadoViewModel
    {
        public IList<TabelaViewModel> Tabelas { get; set; }

        public double ValorFinanciado { get; set; }

        public double TaxaDeJurosMensal { get; set; }

        public int Periodo { get; set; }

        public ResultadoViewModel(IList<TabelaViewModel> tabelas, double valorFinanciado, double taxaDeJurosMensal, int periodo)
        {
            Tabelas = tabelas;
            ValorFinanciado = valorFinanciado;
            TaxaDeJurosMensal = taxaDeJurosMensal;
            Periodo = periodo;
        }
    }
}
