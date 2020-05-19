using System;
using System.Collections.Generic;
using legodb.Models;
using legodb.Repositories;

namespace legodb.Services
{
  public class LegosService
  {
    private readonly LegosRepository _repo;

    public LegosService(LegosRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Lego> GetAll()
    {
      return _repo.GetAll();
    }
    internal IEnumerable<Lego> GetLegosByUserEmail(string creatorEmail)
    {
      return _repo.GetLegosByUserEmail(creatorEmail);
    }
    internal IEnumerable<TagLegoViewModel> GetLegosByTagId(int id)
    {
      return _repo.GetLegosByTagId(id);
    }

    internal Lego Create(Lego newLego)
    {
      Lego createdLego = _repo.Create(newLego);
      return createdLego;
    }

    internal Lego GetById(int id)
    {
      Lego foundLego = _repo.GetById(id);
      if (foundLego == null)
      {
        throw new Exception("Invalid id.");
      }
      return foundLego;
    }

    internal Lego Delete(int id)
    {
      Lego foundLego = GetById(id);
      if (_repo.Delete(id))
      {
        return foundLego;
      }
      throw new Exception("Something bad happened...");
    }


    internal Lego Edit(int id, Lego updatedLego)
    {
      Lego foundLego = GetById(id);
      //NOTE GetById() is already handling our null checking
      foundLego.Title = updatedLego.Title;
      return _repo.Edit(foundLego);
    }

  }
}