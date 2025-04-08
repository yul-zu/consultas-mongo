using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/lt")]
    public class LtController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public LtController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Metros terreno menor a 600
        [HttpGet("metros-terreno")]
        public IActionResult MetrosTerreno()
        {
            var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosTerreno, 600);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Metros construcción menor a 156
        [HttpGet("metros-construccion")]
        public IActionResult MetrosConstruccion()
        {
            var filtro = Builders<Inmueble>.Filter.Lt(x => x.MetrosConstruccion, 156);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Menos de 3 baños
        [HttpGet("baños")]
        public IActionResult Baños()
        {
            var filtro = Builders<Inmueble>.Filter.Lt(x => x.Banios, 3);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Costo menor a 400,000
        [HttpGet("costo")]
        public IActionResult Costo()
        {
            var filtro = Builders<Inmueble>.Filter.Lt(x => x.Costo, 400000);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Fecha de publicación menor a 2025-01-05
        [HttpGet("fecha-publicacion")]
        public IActionResult FechaPublicacion()
        {
            var filtro = Builders<Inmueble>.Filter.Lt(x => x.FechaPublicacion, "2025-01-05");
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
