using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ReviewsRepository
  {
    private readonly IDbConnection _db;

    public ReviewsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Review GetById(int id)
    {
      string sql = "SELECT * FROM reviews WHERE id = @id LIMIT 1";
      return _db.QueryFirstOrDefault<Review>(sql, new { id });
    }

    internal Review Create(Review newReview)
    {
      string sql = @"
      INSERT INTO reviews
      (title, body, rating, productId, creatorId)
      VALUES
      (@Title, @Body, @Rating, @ProductId, @CreatorId);
      SELECT LAST_INSERT_ID()";
      newReview.Id = _db.ExecuteScalar<int>(sql, newReview);
      return newReview;
    }

    internal Review Edit(Review update)
    {
      string sql = @"
      UPDATE reviews
      SET
       title = @Title,
       body = @Body,
       rating = @Rating
      WHERE id = @Id";
      _db.Execute(sql, update);
      return update;
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM reviews WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    // NOTE One to Many Getter
    internal IEnumerable<Review> GetByProductId(int id)
    {
      string sql = "SELECT * FROM reviews WHERE productId = @id";
      return _db.Query<Review>(sql, new { id });
    }
  }
}