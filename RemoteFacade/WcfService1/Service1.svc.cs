using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService1.DtoConverter;
using WcfService1.Mapper;
using WcfService1.Model;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        
        List<ProductDTO> IService1.GetProducts()
        {
            List<Product> products = new List<Product>();
            // Ürün Mapper
            ProductMapper productMapper = new ProductMapper();
            // Tüm ürünleri yükle
            products = productMapper.GetAllProducts();
            // Ürünleri dönüştür ve geri gönder
            return ProductConverter.CretateProductDto(products);
        }
    }
}
