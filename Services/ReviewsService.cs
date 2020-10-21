using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ReviewsService
  {
    private readonly ReviewsRepository _repo;
    private readonly ProductsRepository _prodRepo;

    public ReviewsService(ReviewsRepository repo, ProductsRepository prodRepo)
    {
      _repo = repo;
      _prodRepo = prodRepo;
    }

    internal Review GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Review Create(Review newReview)
    {
      return _repo.Create(newReview);
    }

    internal Review Edit(Review update)
    {
      var original = GetById(update.Id);
      if (original == null)
      {
        throw new Exception("Bad Request");
      }
      if (original.CreatorId != update.CreatorId)
      {
        throw new Exception("Invalid Permissions");
      }
      update.ProductId = original.ProductId;
      update.Title = update.Title != null ? update.Title : original.Title;
      update.Body = update.Body != null ? update.Body : original.Body;

      return _repo.Edit(update);
    }

    internal String Delete(int id, string userId)
    {
      var original = GetById(id);
      if (original == null)
      {
        throw new Exception("Bad Request");
      }
      if (original.CreatorId != userId)
      {
        throw new Exception("Invalid Permissions");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }

    internal IEnumerable<Review> GetByProductId(int id)
    {
      // RULE Check that the parent id exists before fetching children
      var prod = _prodRepo.GetById(id);
      if (prod == null)
      {
        throw new Exception("Invalid Product Id");
      }
      return _repo.GetByProductId(id);
    }
  }
}