using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/in")]
    public class InController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public InController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Operación "Venta" o "Renta"
        [HttpGet("operacion")]
        public IActionResult Operacion()
        {
            var filtro = Builders<Inmueble>.Filter.In(x => x.Operacion, new[] { "Venta", "Renta" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Agente "Luis Fernández" o "María López"
        [HttpGet("nombre-agente")]
        public IActionResult NombreAgente()
        {
            var filtro = Builders<Inmueble>.Filter.In(x => x.NombreAgente, new[] { "Luis Fernández", "María López" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Agencia "Torres Realty" o "Inmuebles Express"
        [HttpGet("agencia")]
        public IActionResult Agencia()
        {
            var filtro = Builders<Inmueble>.Filter.In(x => x.Agencia, new[] { "Torres Realty", "Inmuebles Express" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) TipoPropiedad "Casa" o "Departamento"
        [HttpGet("tipo")]
        public IActionResult Tipo()
        {
            var filtro = Builders<Inmueble>.Filter.In(x => x.Tipo, new[] { "Casa", "Departamento" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Número de baños 1 o 2
        [HttpGet("baños")]
        public IActionResult Baños()
        {
            var filtro = Builders<Inmueble>.Filter.In(x => x.Banios, new[] { 1, 2 });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
