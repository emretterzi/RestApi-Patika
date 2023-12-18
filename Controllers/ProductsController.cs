using RestApi.Dto;

namespace RestApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 19.99m },
        new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 29.99m },
        new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 39.99m },
        new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 49.99m }
    };

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(product); // 200 OK
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request
        }

        product.Id = _products.Count + 1;
        _products.Add(product);

        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product); // 201 Created
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
        {
            return NotFound(); // 404 Not Found
        }

        existingProduct.Name = updatedProduct.Name;
        existingProduct.Description = updatedProduct.Description;
        existingProduct.Price = updatedProduct.Price;

        return Ok(existingProduct); // 200 OK
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(); // 404 Not Found
        }

        _products.Remove(product);

        return NoContent(); // 204 No Content
    }

    [HttpGet("list")]
    public IActionResult ListProducts([FromQuery] string name)
    {
        var filteredProducts = _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return Ok(filteredProducts);
    }
    
    
    [HttpPatch("{id}")]
    public IActionResult PatchProduct(int id, Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = product.Name ?? existingProduct.Name;
        existingProduct.Price = product.Price != 0 ? product.Price : existingProduct.Price;

        return NoContent();
    }

}
