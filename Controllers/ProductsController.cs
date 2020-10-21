using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmaZen.Models;
using AmaZen.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductsController : ControllerBase
  {
    private readonly ProductsService _service;
    private readonly ReviewsService _reviewService;

    public ProductsController(ProductsService ps, ReviewsService rs)
    {
      _service = ps;
      _reviewService = rs;
    }

    [HttpGet]
    public ActionResult<Product> Get()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]  // NOTE '{}' signifies a var parameter
    public ActionResult<Product> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/reviews")] // api/products/:id/reviews
    public ActionResult<IEnumerable<Review>> GetReviews(int id)
    {
      try
      {
        return Ok(_reviewService.GetByProductId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    [Authorize]
    // NOTE ANYTIME you need to use Async/Await you will return a Task
    public async Task<ActionResult<Product>> Create([FromBody] Product newProd)
    {
      try
      {
        // NOTE HttpContext == 'req'
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newProd.CreatorId = userInfo.Id;
        return Ok(_service.Create(newProd));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> Edit([FromBody] Product updated, int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.CreatorId = userInfo.Id;
        updated.Id = id;
        return Ok(_service.Edit(updated));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Product>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}