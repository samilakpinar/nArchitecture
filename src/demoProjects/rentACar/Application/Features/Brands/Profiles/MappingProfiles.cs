using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        //buraya mappleme profilleri yazılır.
        public MappingProfiles() 
        {
            CreateMap<Brand,CreatedBrandDto>().ReverseMap(); //bu ikisi karşılaşırsa Brandi CreateBrandDto ya çevir , //ReverseMap() ile iki türlü mappleme çalışır.
            CreateMap<Brand, CreateBrandCommand>().ReverseMap(); 
        }
    }
}
