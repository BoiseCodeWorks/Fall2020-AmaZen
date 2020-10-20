using System.ComponentModel.DataAnnotations;

namespace AmaZen.Models
{
  // NOTE if you forget to add "public" is "Inconsistent Accesibilty"
  public class Product
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
  }

  // getting all products by list id
  public class WishListProductViewModel : Product
  {
    // Inherits from Product and adds relationship id
    public int WishListProductId { get; set; }
  }

}