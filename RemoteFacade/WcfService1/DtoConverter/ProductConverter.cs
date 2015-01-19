using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.Mapper;
using WcfService1.Model;

namespace WcfService1.DtoConverter
{
    public class ProductConverter
    {
        public static List<ProductDTO> CretateProductDto(List<Product> products)
        {
            List<ProductDTO> productsDto = new List<ProductDTO>();
            ProductMapper mapper = new ProductMapper();
            foreach (Product pr in products)
            {
                ProductDTO dto = new ProductDTO();
                dto.Id = pr.ProductId;
                dto.ProductName = pr.ProductName;
                dto.ProductCategoryId = pr.ProductCategoryId;
                dto.ProductCategoryName = mapper.GetProductCategory(pr.ProductCategoryId).CategoryName;
                productsDto.Add(dto);
            }
            return productsDto;
        }
    }
}