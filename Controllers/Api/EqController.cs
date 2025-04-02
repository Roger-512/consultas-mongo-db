using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller{
    [HttpGet("terrenos-venta")]
    public IActionResult TerrenosVenta(){
        //Muestra todos los que tengan su terreno en venta
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        var filtroVenta = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Venta");
        var filtroTerreno = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroVenta, filtroTerreno);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}