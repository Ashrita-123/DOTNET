using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using WebAPIProductMicroService.Models;
using WebAPIProductMicroService.Repository;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIProductMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)//we directly cant use for crud operation thats why we assign in _productRepository variable
        {
          _productRepository = productRepository;
        }
    // GET: api/<ProductController>
    [HttpGet]
     public IActionResult Get() //IActionResult is the super most return type of all method
        {
         var products = _productRepository.GetProducts(); //bcz return type is any type thats why using var type
            return new OkObjectResult(products);
     }
    //public IEnumerable<string> Get()
    //{
    //    return new string[] { "value1", "value2" };
    //}

    // GET api/<ProductController>/5
    [HttpGet("{id}", Name = "Get")]
    public IActionResult Get(int id) 
    {
      var product = _productRepository.GetProductById(id); 
      return new OkObjectResult(product);
    }
    //public string Get(int id)
    //{
    //    return "value";
    //}

    // POST api/<ProductController>
    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
      using (var scope = new TransactionScope())
      {
         _productRepository.InsertProduct(product);
        scope.Complete();
        return CreatedAtAction(nameof(Get), new { id = product.Id}, product);
      }
    }
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<ProductController>/5
        [HttpPut]//("{id}")
        public IActionResult Put([FromBody] Product product)
        {
          if (product != null)
          {
             using (var scope = new TransactionScope())
             {
                _productRepository.UpdateProduct(product);
                scope.Complete();
                return new OkResult();
             }
          }
          return new NoContentResult();
        }
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
         _productRepository.DeleteProduct(id);
         return new OkResult();
        }
    }
}
