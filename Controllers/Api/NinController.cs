using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
[ApiController]
[Route("api/eq")]
public class EqController : Controller {
    [HttpGet("terreno-re")]
    public IActionResult TerrenoRenta(){
        return Ok();
    }
}