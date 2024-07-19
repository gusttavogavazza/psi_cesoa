using C067058.Application.Dto;

namespace C067058.Application.Interfaces
{
    public interface ISimuladorDeEmprestimoAppService
    {
        IList<SimuladorBaseAppDto> Calcular(decimal valor, decimal taxa, int periodo);
    }
}
