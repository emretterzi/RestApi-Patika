namespace RestApi.Dto;

using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
    public decimal Price { get; set; }
    

    public Product(int ıd, string name, string description, decimal price)
    {
        Id = ıd;
        Name = name;
        Description = description;
        Price = price;
    }

    public Product()
    {
        
    }
}
