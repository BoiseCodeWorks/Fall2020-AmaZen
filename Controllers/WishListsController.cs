using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WishListsController : ControllerBase
  {
    private readonly WishListsService _service;
    private readonly ProductsService _prodService;

    public WishListsController(WishListsService service, ProductsService prodService)
    {
      _service = service;
      _prodService = prodService;
    }

    [HttpGet("{id}")]
    public ActionResult<WishList> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (AccessViolationException e)
      {
        return Forbid(e.Message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")] // api/lists/:id/products
    public ActionResult<IEnumerable<WishListProductViewModel>> GetProducts(int id)
    {
      try
      {
        return Ok(_prodService.GetProductsByListId(id));
      }
      catch (AccessViolationException e)
      {
        return Forbid(e.Message);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<WishList> Create([FromBody] WishList newWishList)
    {
      try
      {
        return Ok(_service.Create(newWishList));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<WishList> Edit([FromBody] WishList update, int id)
    {
      try
      {
        update.Id = id;
        return Ok(_service.Edit(update));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<String> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }

}