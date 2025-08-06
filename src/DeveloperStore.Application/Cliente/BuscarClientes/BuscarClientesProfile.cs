using AutoMapper;
using DeveloperStore.Application.DTO;
using Clientes = DeveloperStore.Domain.Entities.Cliente;

namespace DeveloperStore.Application.Cliente.BuscarClientes
{
    public class BuscarClientesProfile:Profile
    {
        public BuscarClientesProfile()
        {
            CreateMap<Clientes, BuscarClientesResult>();
            CreateMap<Clientes, ClienteDTO>();

       
        }
    }
}
