using RestApi.Dto;

namespace RestApi.Service;

public interface IProductService
{
    List<Product> GetProducts();
    Product GetProductById(int id);
    void CreateProduct(Product product);
    void UpdateProduct(int id, Product updatedProduct);
    void DeleteProduct(int id);
    List<Product> ListProducts(string name);
    void PatchProduct(int id, Product product);
}