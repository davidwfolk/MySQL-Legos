using System.Collections.Generic;
using legodb.Models;
using legodb.Services;
using Microsoft.AspNetCore.Mvc;

namespace legodb.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SetsController : ControllerBase
  {
    private readonly SetsService _ts;

    private readonly LegosService _bs;

    public SetsController(SetsService ts, LegosService bs)
    {
      _ts = ts;
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Set>> GetAll()
    {
      try
      {
        return Ok(_ts.GetAll());
      }
      catch (System.Exception)
      {

        throw;
      }
    }

    // [HttpGet("{id}/legos")]
    // public ActionResult<IEnumerable<SetLegoViewModel>> GetLegosBySetId(int id)
    // {
    //   try
    //   {
    //     //NOTE We could go request to get the tag, and make sure it exists right here by using the tag service.
    //     return Ok(_bs.GetLegosBySetId(id));
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }


    [HttpPost]
    public ActionResult<Set> Create([FromBody] Set newSet)
    {
      try
      {
        return Ok(_ts.Create(newSet));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}