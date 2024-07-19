using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace C067058.Site.Models.Index
{
    public class SeiViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Valor do empréstimo")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Taxa de juros mensal")]
        public decimal TaxaDeJuros { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        //[Range(1, int.MaxValue, ErrorMessage = "Valor informado deve ser maior que zero")]
        [DisplayName("Período (em meses)")]
        public int Periodo { get; set; }
    }
}
