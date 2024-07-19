using C067058.Application.Interfaces;
using C067058.Application.Services.SimuladorDeEmprestimo;
using C067058.Domain.Interfaces.Services.SimuladorDeEmprestimo;
using C067058.Domain.ServicesDomain.SimuladorDeEmprestimo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace C067058.Infra.IoC
{
    public class Registrador
    {
        public static void Registrar(WebApplicationBuilder builder)
        {
            /** Application **/
            builder.Services.AddScoped<ISimuladorDeEmprestimoAppService, SimuladorDeEmprestimoAppService>();
            /*********************/

            /** Services Domain **/
            builder.Services.AddScoped<ISimuladorSacServiceDomain, SimuladorSacServiceDomain>();
            builder.Services.AddScoped<ISimuladorPriceServiceDomain, SimuladorPriceServiceDomain>();
            /*********************/

        }
    }
}
