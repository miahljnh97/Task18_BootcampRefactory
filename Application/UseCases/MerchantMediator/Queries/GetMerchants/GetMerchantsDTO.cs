using System;
using System.Collections.Generic;
using Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchant;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsDTO : BaseDTO
    {
        public List<MerchantData> Data { get; set; }
    }
}
