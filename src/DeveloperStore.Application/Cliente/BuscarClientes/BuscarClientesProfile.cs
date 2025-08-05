using AutoMapper;
using Clientes = DeveloperStore.Domain.Entities.Cliente;

namespace DeveloperStore.Application.Cliente.BuscarClientes
{
    public class BuscarClientesProfile:Profile
    {
        public BuscarClientesProfile()
        {
            CreateMap<BuscarClientesResult, Clientes>();
        }
    }
}
