using System;
using System.Collections.Generic;
using legodb.Models;
using legodb.Repositories;

namespace legodb.Services
{
  public class SetsService
  {
    private readonly SetsRepository _repo;

    public SetsService(SetsRepository repo)
    {
      _repo = repo;
    }
    internal Set Create(Set newSet)
    {
      return _repo.Create(newSet);
    }

    internal IEnumerable<Set> GetAll()
    {
      return _repo.GetAll();
    }
  }
}


