using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lte")]
public class LteController : Controller {
    [HttpGet("casa-precio")]
    public IActionResult CasaPrecio(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades con un costo de $500,000 o menos.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, costo);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-baños")]
    public IActionResult PropiedadesBaños(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades con máximo 2 baños.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Bnios, 2);
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casas-pisos")]
    public IActionResult CasasPisos(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las casas con máximo 2 pisos.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Pisos, 2);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-publicacion")]
    public IActionResult PropiedadesPublicacion(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades publicadas el 30 de enero de 2025 o antes.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.FechaPublicacion, "2025/01/30");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-terreno")]
    public IActionResult PropiedadesTerreno(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades con máximo 600 metros de terreno.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosTerreno, 600);
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}