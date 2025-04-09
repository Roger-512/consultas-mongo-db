using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/nin")]
public class NinController : Controller {
    [HttpGet("propiedades-baños")]
    public IActionResult PropiedadesBaños(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no tenga ni 1 ni 2 baños.
        List<int> valores = new List<int>();
        valores.Add(1);
        valores.Add(2);

        var filtroCompuesto = Builders<Inmueble>.Filter.Nin(x => x.Bnios, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-agencias")]
    public IActionResult PropiedadesAgencias(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no sean de las agencias "Torres Realty" ni "Fernández Inmuebles".
        List<string> valores = new List<string>();
        valores.Add("Torres Realty");
        valores.Add("Fernández Inmuebles");

        var filtroCompuesto = Builders<Inmueble>.Filter.Nin(x => x.Agencia, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-fecha")]
    public IActionResult PropiedadesFecha(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no fueron publicadas el 11, 14 de enero.
        List<string> valores = new List<string>();
        valores.Add("2025/01/11");
        valores.Add("2025/01/14");

        var filtroCompuesto = Builders<Inmueble>.Filter.Nin(x => x.FechaPublicacion, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedades-pisos")]
    public IActionResult PropiedadesPisos(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no tengan 1 ni 2 pisos.
        List<int> valores = new List<int>();
        valores.Add(1);
        valores.Add(2);

        var filtroCompuesto = Builders<Inmueble>.Filter.Nin(x => x.Pisos, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }

    [HttpGet("propiedad-baños")]
    public IActionResult PropiedadBaños(){
        MongoClient client = new MongoClient(CadenasConexion.MongoDB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVentas");

        //Muestra todas las propiedades que no tengan 0 ni 3 baños.
        List<int> valores = new List<int>();
        valores.Add(0);
        valores.Add(3);

        var filtroCompuesto = Builders<Inmueble>.Filter.Nin(x => x.Bnios, valores);
        var lista = collection.Find(filtroCompuesto).ToList();
        return Ok(lista);
    }
}