using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legodb.Models;

namespace legodb.Repositories
{
  public class SetsRepository
  {
    private readonly IDbConnection _db;

    public SetsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Set Create(Set newSet)
    {
      string sql = @"
        INSERT INTO sets
        (title)
        VALUES
        (@Title);
        SELECT LAST_INSERT_ID()";
      newSet.Id = _db.ExecuteScalar<int>(sql, newSet);
      return newSet;
    }

    internal IEnumerable<Set> GetAll()
    {
      string sql = "SELECT * FROM sets";
      return _db.Query<Set>(sql);
    }
  }
}