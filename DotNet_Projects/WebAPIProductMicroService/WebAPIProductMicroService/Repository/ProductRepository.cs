using Microsoft.EntityFrameworkCore;
using WebAPIProductMicroService.DBContexts;
using WebAPIProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIProductMicroService.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ProductContext _dbContext;

       public ProductRepository(ProductContext dbContext)
       {
          _dbContext = dbContext;
       }
      public void DeleteProduct(int productId)
      {
        var product = _dbContext.Products.Find(productId);
        _dbContext.Products.Remove(product);
        Save();
      }
      public Product GetProductById(int productId)
      {
        return _dbContext.Products.Find(productId);
      }

        //public Product GetProductById(int ProductId)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Product> GetProducts()
      {
        return _dbContext.Products.ToList();
      }
      public void InsertProduct(Product product)
      {
        _dbContext.Add(product);
        Save();
      }
      public void Save()
      {
        _dbContext.SaveChanges();
      }
      public void UpdateProduct(Product product)
      {
        _dbContext.Entry(product).State = EntityState.Modified;
         Save();
      }
}
}
