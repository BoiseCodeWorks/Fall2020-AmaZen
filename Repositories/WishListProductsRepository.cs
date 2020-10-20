using System;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WishListProductsRepository
  {
    private readonly IDbConnection _db;

    public WishListProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal void Create(WishListProduct newWLP)
    {
      string sql = @"
      INSERT INTO wishlistproducts
      (productId, wishlistId)
      VALUES
      (@ProductId, @WishlistId);";
      _db.Execute(sql, newWLP);
    }
    internal WishListProduct GetById(int id)
    {
      string sql = "SELECT * FROM wishlistproducts WHERE id = @id;";
      return _db.QueryFirstOrDefault<WishListProduct>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM wishlistproducts WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }


  }
}