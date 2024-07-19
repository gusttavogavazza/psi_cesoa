namespace C067058.Application.Dto
{
    public class SimuladorBaseAppDto
    {
        public string Identificacao { get; set; }

        public IList<PrestacaoAppDto> Prestacoes { get; set; }

        public double Total { get; set; }

        public double TotalAmortizacaoMensal { get; set; }

        public double TotalJurosMensal { get; set; }
    }
}
