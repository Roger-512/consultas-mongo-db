using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/gt")]
public class GtController : Controller {
    [HttpGet("terreno-valor")]
    public IActionResult TerrenoValor(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroCosto = Builders<Inmueble>.Filter.Gt(x => x.Costo, 100000);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");

        //Muestra todos los que su terreno vale más de $100,000

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroCosto, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("terreno-metros")]
    public IActionResult TerrenoMetros(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroMetro = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 500);

        //Muestra todos los que cuentan con un terreno de más de 500 metros

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroMetro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-piso")]
    public IActionResult CasaPiso(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroPiso = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 2);

        //Muestra todos los que ofrecen una casa con más de 1 piso

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroPiso);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-baños")]
    public IActionResult CasaBaños(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroBanios = Builders<Inmueble>.Filter.Gt(x => x.Bnios, 2);

        //Muestra todas las casas que cuentan con más de un baño

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroBanios);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-metros")]
    public IActionResult CasaMetros(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");
        var filtroTerreno = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 301);
        var filtroTipo = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");

        //Muestra todas las casas que tengan más de 300 metros de terreno. :)

        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroTerreno, filtroTipo);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

}