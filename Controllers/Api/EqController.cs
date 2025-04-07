using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/eq")]
public class EqController : Controller {
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


    [HttpGet("metros-construccion")]
    public IActionResult MetrosConstruccion(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroMetros = Builders<Inmueble>.Filter.Eq(x => x.MetrosConstruccion, 0);

        //Muestra todos los que no han construido en su terreno

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroMetros);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casas-patio")]
    public IActionResult CasasPatio(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroPatio = Builders<Inmueble>.Filter.Eq(x => x.TienePatio, false);

        //Muestra todas las casas que no tienen patio

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroPatio);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("Inmobiliaria-Perez")]
    public IActionResult    InmobiliariaPerez(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroPatio = Builders<Inmueble>.Filter.Eq(x => x.Agencia, "Torres Realty");

        //Muestra todos los que su agencia sea “Inmobiliaria Pérez"

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroPatio);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("venta-febrero")]
    public IActionResult VentaFebrero(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroFecha = Builders<Inmueble>.Filter.Eq(x => x.FechaPublicacion, "2025-02-26");

        //Muestra todos los que compraron su terreno en febrero del 2025

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroFecha);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}