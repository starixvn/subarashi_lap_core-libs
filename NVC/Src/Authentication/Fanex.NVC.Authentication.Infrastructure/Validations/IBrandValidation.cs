using System.Collections.Generic;

namespace Fanex.NVC.Authentication.Infrastructure
{
    public interface IBrandValidation
    {
        bool IsValidBrandId(IBrandIdMetaModel model, IEnumerable<Brand> allowedBrands);

        bool IsValidBrandIdList(IBrandIdListMetaModel model, IEnumerable<Brand> allowedBrands);
    }
}