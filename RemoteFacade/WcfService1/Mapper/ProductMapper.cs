using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WcfService1.Model;

namespace WcfService1.Mapper
{
    public class ProductMapper
    {
        // Ürün listesi
        private List<Product> products = new List<Product>();
        // Kategori listesi
        private List<Category> categories = new List<Category>();
        public ProductMapper()
        {
            this.FillProducts();
            this.FillCategories();
        }
        public List<Product> GetAllProducts()
        {
            return this.products;
        }

        public Category GetProductCategory(int categoryId)
        {
            return this.categories.Where(i=> i.CategoryId == categoryId).FirstOrDefault();
        }

        private void FillProducts()
        {
            this.products.Add(new Product() { ProductName="Ürün 1",ProductCategoryId=1});
            this.products.Add(new Product() { ProductName="Ürün 2",ProductCategoryId=2});
            this.products.Add(new Product() { ProductId=3,ProductName="Ürün 3",ProductCategoryId=3});
        }

        private void FillCategories()
        {
            this.categories.Add(new Category() { CategoryId=1,CategoryName="Kategori 1"});
            this.categories.Add(new Category() { CategoryId = 2, CategoryName = "Kategori 2" });
            this.categories.Add(new Category() { CategoryId = 3, CategoryName = "Kategori 3" });
        }


    }
}