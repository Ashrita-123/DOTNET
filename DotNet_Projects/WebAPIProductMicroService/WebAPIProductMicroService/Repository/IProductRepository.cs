using WebAPIProductMicroService.Models;
using System.Collections.Generic;


namespace WebAPIProductMicroService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int ProductId);
        void InsertProduct(Product Product);
        void DeleteProduct(int ProductId);
        void UpdateProduct(Product Product);
        void Save();
        //object GetProductByID(int id);
    }
}
