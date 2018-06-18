using AutoMapper;
using MicroBolt.Stock.Bolts.Dto;
using MicroBolt.Stock.Data.Contracts.Entity;
using MicroBolt.Stock.Models;
using MicroBolt.Stock.Products.Dto;

namespace MicroBolt.Stock.IoC.MapperProfiles
{
    public class BoltProfile : Profile
    {
        public BoltProfile()
        {
            CreateMap<Product, ProductModel>()
                .Include<Bolt, BoltModel>();

            CreateMap<BaseProductDto, ProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .Include<BaseBoltDto, BoltModel>();

            CreateMap<Bolt, BoltModel>();

            CreateMap<BaseBoltDto, BoltModel>()
                .Include<GetBoltDto, BoltModel>()
                .Include<CreateOrUpdateBoltDto, BoltModel>();

            CreateMap<GetBoltDto, BoltModel>();
            CreateMap<CreateOrUpdateBoltDto, BoltModel>();
        }
    }
}
