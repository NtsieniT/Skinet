using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;
using Skinet.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skinet.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _conguration;

        public ProductUrlResolver(IConfiguration  conguration)
        {
            _conguration = conguration;
        }

        // 
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _conguration["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
