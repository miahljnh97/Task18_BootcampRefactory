using System;
using System.Collections.Generic;
using Task18_BootcampRefactory.Application.UseCases.ProductMediator.Queries.GetProduct;
using Task18_BootcampRefactory.Model;

namespace Task18_BootcampRefactory.Application.UseCases.ProductMediator.Request
{
    public class ProductDTO : BaseDTO
    {
        List<ProductData> Data { get; set; }
    }
}
