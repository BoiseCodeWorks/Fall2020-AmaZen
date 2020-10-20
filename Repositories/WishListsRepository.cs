using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class WishListsRepository
  {
    private readonly IDbConnection _db;

    public WishListsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal WishList GetById(int id)
    {
      string sql = "SELECT * FROM wishlists WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<WishList>(sql, new { id });
    }

    internal WishList Create(WishList newWishList)
    {
      string sql = @"
      INSERT INTO wishlists
      (title)
      VALUES
      (@Title);
      SELECT LAST_INSERT_ID()";
      newWishList.Id = _db.ExecuteScalar<int>(sql, newWishList);
      return newWishList;
    }

    internal WishList Edit(WishList update)
    {
      string sql = @"
      UPDATE wishlists
      SET
       title = @Title
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM wishlists WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}