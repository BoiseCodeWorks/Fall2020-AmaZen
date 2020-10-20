using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishListProductsController : ControllerBase
  {
    private readonly WishListProductsService _service;

    public WishListProductsController(WishListProductsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<string> Create([FromBody] WishListProduct newWLP)
    {
      try
      {
        _service.Create(newWLP);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete 
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("success");
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}