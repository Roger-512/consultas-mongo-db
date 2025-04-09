using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/ne")]
public class NeController : Controller {
    [HttpGet("propiedad-precio")]
    public IActionResult PropiedadPrecio(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades con un costo de $500,000 o menos.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, costo);
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-agencia")]
    public IActionResult PropiedadesAgencia(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no sean de la agencia "López Bienes Raíces".

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Agencia, "López Bienes Raíces");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-fecha")]
    public IActionResult PropiedadesFecha(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no fueron publicadas en febrero de 2025.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.FechaPublicacion, "2025/02/01");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-baños")]
    public IActionResult PropiedadesBaños(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no tengan más de 2 baños

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Bnios, 2);
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-agencias")]
    public IActionResult PropiedadesAgencias(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no sean de "María López".

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Agencia, "María López");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}