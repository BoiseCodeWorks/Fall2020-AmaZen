using System;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WishListProductsService
  {
    private readonly WishListProductsRepository _repo;

    public WishListProductsService(WishListProductsRepository repo)
    {
      _repo = repo;
    }

    internal void Create(WishListProduct newWLP)
    {
      _repo.Create(newWLP);
    }

    internal void Delete(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Delete(id);
    }
  }
}