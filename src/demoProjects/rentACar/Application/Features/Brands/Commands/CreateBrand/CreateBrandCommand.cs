using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto> //using Mediatr // CreatedBrandDto işlem sonudunda döndürülecek datadır. veri tabanında oluşuturlacak ID ile sözünü veriyoruz.
    {
        public string Name { get; set; } //Marka yaratmak için Kullanıcından isim alıyoruz.

        //Böyle bir command sıraya koyulursa Hangi handler çalılacak ona da bi  send IRequestHandlersın diyerek çalışacak Handlerı buluyor.
        //Ayrı bir dosya içinde de olabilir.
        //İnterfaceden gelen Handle() implemente edilir.
        public class CreatedBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto> //Handlerda çalışılacak command ve dönüş tipi belirtiliyor. request, response alıyor
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                //iş kuralları buraya yazarız.
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request); //gelen requesti Brand nesnesine çevir. yani veritabanı nesnesine.
                Brand createdBrand= await _brandRepository.AddAsync(mappedBrand); //oluşturulan brand veritabanı nesnesini ekleme metoduna parametre olarak gönder.
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand); //veritabanını nesnesini kullanıcıya dönmek için Dto kullan ve veritabanı nesnesini kullanıcıya dönme.
                
                return createdBrandDto;
            }
        }
    }
}
