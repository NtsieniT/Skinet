using AutoMapper;
using Core.Entities;
using Skinet.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(b => b.ProductBrand,
                source => source.MapFrom(s => s.ProductBrand.Name))
                .ForMember(t => t.ProductType,
                source => source.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
