using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lt")]
public class LtController : Controller {
    [HttpGet("terreno-precio")]
    public IActionResult TerrenoPrecio(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todos los terrenos con un precio menor a $80,000

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, costo);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-baño")]
    public IActionResult CasaBaño(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las casas con menos de 2 baños

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Bnios, 2);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("terreno-metros")]
    public IActionResult TerrenoMetros(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades con un terreno menor a 200 metros cuadrados.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosTerreno, 200);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Terreno");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-fecha")]
    public IActionResult CasaFecha(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades listadas antes de diciembre de 2025.

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.FechaPublicacion, "2025/12/31");
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casa-precio")]
    public IActionResult CasaPrecio(int costo){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las casas con un costo menor a $500,000

        var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, costo);
        var filtro2 = Builders<Inmueble>.Filter.Eq(x => x.Tipo, "Casa");
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtro, filtro2);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}