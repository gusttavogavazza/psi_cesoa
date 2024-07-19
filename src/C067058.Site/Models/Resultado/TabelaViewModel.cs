namespace C067058.Site.Models.Resultado
{
    public class TabelaViewModel
    {
        public string Identificacao { get; set; }

        public IList<TabelaPrestacaoViewModel> Prestacoes { get; set; }

        public double Total { get; set; }

        public double TotalAmortizacaoMensal { get; set; }

        public double TotalJurosMensal { get; set; }
    }
}
