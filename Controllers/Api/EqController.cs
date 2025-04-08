using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/eq")]
    public class EqController : Controller
    {
        private readonly IMongoCollection<Inmueble> collection;

        public EqController()
        {
            var client = new MongoClient(CadenasConexion.MONGO_DB);
            var db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Mostrar registros con operación "Renta"
        [HttpGet("operacion-renta")]
        public IActionResult ObtenerPorOperacion()
        {
            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Operacion, "Renta");
            var lista = collection.Find(filtro).ToList();
            return Ok(lista);
        }

        // b) Mostrar registros con 3 pisos
        [HttpGet("pisos-tres")]
        public IActionResult ObtenerPorPisos()
        {
            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Pisos, 3);
            var lista = collection.Find(filtro).ToList();
            return Ok(lista);
        }

        // c) Mostrar registros con nombre_agente "Carlos Garcia"
        [HttpGet("agente-Carlos-García")]
        public IActionResult ObtenerPorAgente()
        {
            var filtro = Builders<Inmueble>.Filter.Eq(x => x.NombreAgente, "Carlos García");
            var lista = collection.Find(filtro).ToList();
            return Ok(lista);
        }

        // d) Mostrar registros con agencia "Inmobilaria Perez"
        [HttpGet("Inmobiliaria-Pérez")]
        public IActionResult ObtenerPorAgencia()
        {
            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Agencia, "Inmobiliaria Pérez");
            var lista = collection.Find(filtro).ToList();
            return Ok(lista);
        }

        // e) Mostrar registros que NO tienen baños (null o 0)
        [HttpGet("sin-baños")]
        public IActionResult ObtenerSinBanios()
        {
            var filtro = Builders<Inmueble>.Filter.Eq(x => x.Banios, 0);
            var lista = collection.Find(filtro).ToList();
            return Ok(lista);
        }
    }
}



