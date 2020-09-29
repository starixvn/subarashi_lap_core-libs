using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanex.NVC.Authentication.Infrastructure
{
    public class BrandValidation : IBrandValidation
    {
        public bool IsValidBrandId(IBrandIdMetaModel model, IEnumerable<Brand> allowedBrands)
        {
            if (model == null)
            {
                return false;
            }

            return allowedBrands.Any(brand => brand.Id == model.BrandId);
        }

        public bool IsValidBrandIdList(IBrandIdListMetaModel model, IEnumerable<Brand> allowedBrands)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.BrandIds))
            {
                return false;
            }

            var brandIdList = model.BrandIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> existInBrandList = brandId => int.TryParse(brandId, out int _brandId) &&
                                                                allowedBrands.Any(brand => _brandId == brand.Id);
            return brandIdList.All(existInBrandList);
        }
    }
}