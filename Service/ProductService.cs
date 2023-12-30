using RestApi.Dto;

namespace RestApi.Service;

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;


    public class ProductService : IProductService
    {
        private readonly List<Product> _products;
        private readonly ILogger<ProductService> _logger;

        public ProductService(ILogger<ProductService> logger)
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 19.99m },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 29.99m },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 39.99m },
                new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 49.99m }
            };

            _logger = logger;
        }

        public List<Product> GetProducts()
        {
            _logger.LogInformation("Getting all products.");
            return _products;
        }

        public Product GetProductById(int id)
        {
            _logger.LogInformation($"Getting product with id {id}.");
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {
            _logger.LogInformation("Creating a new product.");

            if (product == null)
            {
                _logger.LogError("Product is null.");
                throw new ArgumentNullException(nameof(product));
            }

            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void UpdateProduct(int id, Product updatedProduct)
        {
            _logger.LogInformation($"Updating product with id {id}.");

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
        }

        public void DeleteProduct(int id)
        {
            _logger.LogInformation($"Deleting product with id {id}.");

            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            _products.Remove(product);
        }

        public List<Product> ListProducts(string name)
        {
            _logger.LogInformation($"Listing products with name containing {name}.");
            return _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void PatchProduct(int id, Product product)
        {
            _logger.LogInformation($"Patching product with id {id}.");

            var existingProduct = _products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
            {
                _logger.LogError($"Product with id {id} not found.");
                throw new KeyNotFoundException($"Product with id {id} not found.");
            }

            existingProduct.Name = product.Name ?? existingProduct.Name;
            existingProduct.Price = product.Price != 0 ? product.Price : existingProduct.Price;
        }
    }