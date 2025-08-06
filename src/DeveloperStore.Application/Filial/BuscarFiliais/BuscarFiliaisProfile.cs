using AutoMapper;
using DeveloperStore.Application.Cliente.BuscarClientes;
using DeveloperStore.Application.DTO;
using DeveloperStore.Domain.Entities;
using Filiais = DeveloperStore.Domain.Entities.Filial;

namespace DeveloperStore.Application.Filial.BuscarFiliais
{
    public class BuscarFiliaisProfile: Profile
    {
        public  BuscarFiliaisProfile()
        {
            CreateMap<Filiais, BuscarFiliaisResult>();
            CreateMap<Filiais, FilialDTO>();

        }
    }
}
