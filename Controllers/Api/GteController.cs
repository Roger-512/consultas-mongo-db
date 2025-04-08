using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gte")]
public class GteController : Controller {
    [HttpGet("terreno-precio")]
    public IActionResult TerrenoPrecio(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroCosto = Builders<Inmueble>.Filter.Gt(x => x.Costo, 150000);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");

        //Muestra todos los terrenos que tienen un precio mayor o igual a $150,000

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroCosto, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-3baños")]
    public IActionResult Casa3Baños(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroBanios = Builders<Inmueble>.Filter.Gt(x => x.Bnios, 3);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");

        //Muestra todas las propiedades que tienen al menos 3 baños

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroBanios, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("terreno-tamaño")]
    public IActionResult TerrenoTamaño(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroMtrs = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 400);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");

        //Muestra todos los terrenos que tienen un tamaño de al menos 400 metros cuadrados

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroMtrs, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-pisos")]
    public IActionResult CasaPisos(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroPiso = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 2);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");

        //Muestra todas las casas que cuentan con al menos dos pisos

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroPiso, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-medida")]
    public IActionResult CasaMedida(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroMedida = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 300);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");

        //Muestra todas las casas que tengan más de 300 metros de terreno

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroMedida, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    
}