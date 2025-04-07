using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
[ApiController]
[Route("api/in")]
public class InController : Controller{
    [HttGet("listar-propiedades-agencia-agente")]
    public IActionResult ListarPropiedadesAgenciaAgente([FromQuery]List<string> agentes) {
        MongoClient client = nwe MongoClient(CadenasConexion.Mongo_DB);
        var db = client.GetDatabase("Inmuebles");
        var collection = db.GetCollection<Inmueble>("RentasVenta");

        // obtener todas las propiedades de la agencia X y de los agentes en la lista 
        var filtroAgencia = Builders<Inmueble>.Filter.Eq(x => x.Agencia, agencia);
        var filtroAgentes = Builders<Inmueble>.Filter.In(x => x.NombreAgente, agentes);
        var filtroCompuesto = Builders<Inmueble>.Filter.And(filtroAgencia, filtroAgentes);

        var list = collection.Find(filtroCompuesto).ToList();
        return Ok (list);
    }


}
