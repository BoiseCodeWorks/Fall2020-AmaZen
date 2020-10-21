using System;
using System.Collections.Generic;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class ProductsService
  {
    private readonly ProductsRepository _repo;

    public ProductsService(ProductsRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Product> GetAll()
    {
      return _repo.GetAll();
    }

    internal Product GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal Product Create(Product newProd)
    {
      return _repo.Create(newProd);
    }

    internal Product Edit(Product updated)
    {
      var data = GetById(updated.Id);
      if (data.CreatorId != updated.CreatorId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      updated.Description = updated.Description != null ? updated.Description : data.Description;
      updated.Title = updated.Title != null && updated.Title.Length > 2 ? updated.Title : data.Title;
      return _repo.Edit(updated);
    }

    internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    {
      return _repo.GetProductsByListId(id);
    }

    internal string Delete(int id, string userId)
    {
      var data = GetById(id);
      if (data.CreatorId != userId)
      {
        throw new Exception("Invalid Edit Permissions");
      }
      _repo.Delete(id);
      return "delorted";
    }
  }
}