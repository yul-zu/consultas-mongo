using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/ne")]
    public class NeController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public NeController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Tipo distinto de "Terreno"
        [HttpGet("tipo")]
        public IActionResult Tipo()
        {
            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Tipo, "Terreno");
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Operación distinta de "Renta"
        [HttpGet("operacion")]
        public IActionResult Operacion()
        {
            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Operacion, "Renta");
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Baños distinto de 2
        [HttpGet("baños")]
        public IActionResult Banios()
        {
            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Banios, 2);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Pisos distinto de 1
        [HttpGet("pisos")]
        public IActionResult Pisos()
        {
            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Pisos, 1);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Costo distinto de 500000
        [HttpGet("costo")]
        public IActionResult Costo()
        {
            var filtro = Builders<Inmueble>.Filter.Ne(x => x.Costo, 500000);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
