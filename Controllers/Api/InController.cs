using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/in")]
public class InController : Controller {
    [HttpGet("operaciones")]
    public IActionResult Operaciones(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades cuya operación sea "Venta" o "Renta"
        List<string> valores = new List<string>();
        valores.Add("Venta");
        valores.Add("Renta");

        var filtroCompuesto = Builders<Inmueble>.Filter.In(x => x.Operacion, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("publicaciones-dias")]
    public IActionResult PublicacionesDias(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades publicadas en los días 11, 14 o 24 de cualquier mes
        List<string> valores = new List<string>();
        valores.Add("2025-02-11");
        valores.Add("2025-02-14");
        valores.Add("2025-02-24");

        var filtroCompuesto = Builders<Inmueble>.Filter.In(x => x.FechaPublicacion, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("agencias")]
    public IActionResult Agencias(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades en las agencias "López Bienes Raíces", "Torres Realty" o "García Propiedades"
        List<string> valores = new List<string>();
        valores.Add("López Bienes Raíces");
        valores.Add("Torres Realty");
        valores.Add("García Propiedades");

        var filtroCompuesto = Builders<Inmueble>.Filter.In(x => x.Agencia, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("casas-patio")]
    public IActionResult CasasPatio(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las terrenos que tienen 500 y 600 metros de terreno
        List<int> valores = new List<int>();
        valores.Add(600);
        valores.Add(500);

        var filtroCompuesto = Builders<Inmueble>.Filter.In(x=> x.MetrosTerreno, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("terreno-fecha")]
    public IActionResult TerrenoFecha(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todo lo que fue comprado en primero de enero, marzo o diciembre
        List<string> valores = new List<string>();
        valores.Add("2025-01-01");
        valores.Add("2025-03-01");
        valores.Add("2025-12-01");

        var filtroCompuesto = Builders<Inmueble>.Filter.In(x => x.FechaPublicacion, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    
}