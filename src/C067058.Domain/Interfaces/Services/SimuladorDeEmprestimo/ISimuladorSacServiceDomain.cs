﻿using C067058.Domain.ServicesDomain.SimuladorDeEmprestimo.Dto;

namespace C067058.Domain.Interfaces.Services.SimuladorDeEmprestimo
{
    public interface ISimuladorSacServiceDomain
    {
        SimuladorBase Calcular(double valorPrincipalDoFinanciamento, double taxaDeJurosMensal, int periodo);
    }
}