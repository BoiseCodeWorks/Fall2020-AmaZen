using System;
using System.Collections.Generic;
using System.Data;
using AmaZen.Models;
using Dapper;

namespace AmaZen.Repositories
{
  public class ProductsRepository
  {
    private readonly IDbConnection _db;
    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal IEnumerable<Product> GetAll()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql);
    }

    internal Product GetById(int id)
    {
      string sql = "SELECT * FROM products WHERE id = @id";
      return _db.QueryFirstOrDefault<Product>(sql, new { id });
    }

    internal Product Create(Product newProd)
    {
      string sql = @"
      INSERT INTO products 
      (title, description, price) 
      VALUES 
      (@Title, @Description, @Price);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newProd);
      newProd.Id = id;
      return newProd;
    }

    internal Product Edit(Product updated)
    {
      string sql = @"
        UPDATE products
        SET
         title = @Title,
         description = @Description,
         price = @Price
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    internal IEnumerable<WishListProductViewModel> GetProductsByListId(int id)
    {
      string sql = @"
      SELECT p.*, wlp.id AS WishListProductId
      FROM wishlistproducts wlp
      JOIN products p ON p.id = wlp.productId
      WHERE wishlistId = @id
      ";
      return _db.Query<WishListProductViewModel>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM products WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}