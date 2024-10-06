using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        //injection
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        //Marka isimleri tekrar edemez.
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name);
            //mantık söyle, hiç bir şey dönmüyorsa kuraldan geçiyor demektir.
            //kuraldan geçmediği her durumda hata fırlatıyor.
            if (result.Items.Any()) throw new BusinessException("Brand name exists."); //veri varsa throw fırlatılacak.
        }
    }
}
