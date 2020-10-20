using System;
using AmaZen.Models;
using AmaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReviewsController : ControllerBase
  {
    private readonly ReviewsService _service;

    public ReviewsController(ReviewsService service)
    {
      _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
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


    [HttpPost]
    public ActionResult<Review> Create([FromBody] Review newReview)
    {
      try
      {
        return Ok(_service.Create(newReview));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Review> Edit([FromBody] Review update, int id)
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