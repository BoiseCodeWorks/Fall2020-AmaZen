using System.ComponentModel.DataAnnotations;

namespace AmaZen.Models
{
  // NOTE if you forget to add "public" is "Inconsistent Accesibilty"
  public class Product
  {

    // NOTE if you get the error "Must provide parameterless default constructor" you need to insure the class has a empty contructor
    // public Product(int id, string title, string description, float price)
    // {
    //   this.Id = id;
    //   this.Title = title;
    //   this.Description = description;
    //   this.Price = price;
    // }

    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
  }

}