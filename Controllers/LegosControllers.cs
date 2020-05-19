using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legodb.Models;
using legodb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace legodb.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LegosController : ControllerBase
  {
    private readonly LegosService _bs;

    public LegosController(LegosService bs)
    {
      _bs = bs;
    }
    // Route path: https://localhost:5001/api/legos
    [HttpGet]
    public ActionResult<IEnumerable<Lego>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    //NOTE decision we made, this route does not follow standard conventions
    // Route path: https://localhost:5001/api/legos/user
    [HttpGet("user")]
    public ActionResult<IEnumerable<Lego>> GetLegosByUserEmail()
    {
      try
      {
        string creatorEmail = "Jerry@momoney.com";
        return Ok(_bs.GetLegosByUserEmail(creatorEmail));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Route path: https://localhost:5001/api/legos/1
    [HttpGet("{id}")]
    public ActionResult<Lego> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    // Route path: https://localhost:5001/api/legos
    [HttpPost]
    public ActionResult<Lego> Create([FromBody] Lego newLego)
    {
      try
      {
        newLego.CreatorEmail = "Jerry@momoney.com";
        return Ok(_bs.Create(newLego));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // Route path: https://localhost:5001/api/legos/1
    [HttpDelete("{id}")]
    public ActionResult<Lego> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Lego> Edit(int id, [FromBody] Lego updatedLego)
    {
      try
      {
        return Ok(_bs.Edit(id, updatedLego));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}
