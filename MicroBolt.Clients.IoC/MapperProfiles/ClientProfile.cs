using System;
using AutoMapper;
using MicroBolt.Clients.Data.Contracts.Entity;
using MicroBolt.Clients.Dto;
using MicroBolt.Clients.Models;

namespace MicroBolt.Clients.IoC.MapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientModel>();

            CreateMap<BaseClientDto, ClientModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .Include<GetClientDto, ClientModel>()
                .Include<CreateOrUpdateClientDto, ClientModel>();

            CreateMap<GetClientDto, GetClientDto>();
            CreateMap<GetClientDto, ClientModel>();
            CreateMap<CreateOrUpdateClientDto, ClientModel>();
        }
    }
}
