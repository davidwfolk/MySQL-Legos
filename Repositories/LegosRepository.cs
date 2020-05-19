using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legodb.Models;

namespace legodb.Repositories
{
  public class LegosRepository
  {
    private readonly IDbConnection _db;

    public LegosRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Lego> GetAll()
    {
      string sql = "SELECT * FROM legos";
      return _db.Query<Lego>(sql);
    }

    internal Lego Create(Lego newLego)
    {
      string sql = @"
      INSERT INTO legos
      (title, creatorEmail)
      VALUES
      (@Title, @CreatorEmail);
      SELECT LAST_INSERT_ID()";
      newLego.Id = _db.ExecuteScalar<int>(sql, newLego);
      return newLego;
    }

    internal IEnumerable<TagLegoViewModel> GetLegosByTagId(int TagId)
    {
      string sql = @"
        SELECT
        b.*,
        t.title As Tag,
        tb.id AS TagLegoId
        FROM taglegos tb
        INNER JOIN legos b ON b.id = tb.legoId
        INNER JOIN tags t ON t.id = tb.TagId
        WHERE tagId = @TagId AND isPublished = 1";
      return _db.Query<TagLegoViewModel>(sql, new { TagId });
    }

    internal IEnumerable<Lego> GetLegosByUserEmail(string creatorEmail)
    {
      string sql = "SELECT * FROM legos WHERE creatorEmail = @CreatorEmail";
      return _db.Query<Lego>(sql, new { creatorEmail });
    }

    internal Lego GetById(int id)
    {
      string sql = "SELECT * FROM legos WHERE id = @Id";
      return _db.QueryFirstOrDefault<Lego>(sql, new { id });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM legos WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }

    internal Lego Edit(Lego legoToUpdate)
    {
      string sql = @"
        UPDATE legos
        SET
          title = @Title,
          body = @Body,
        WHERE id = @Id LIMIT 1";
      _db.Execute(sql, legoToUpdate);
      return legoToUpdate;
    }
  }
}