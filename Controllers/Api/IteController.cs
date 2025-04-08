using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/lte")]
    public class LteController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public LteController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) 2 baños o menos
        [HttpGet("baños")]
        public IActionResult Banios()
        {
            var filtro = Builders<Inmueble>.Filter.Lte(x => x.Banios, 2);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Costo 40,000 o menos
        [HttpGet("costo")]
        public IActionResult Costo()
        {
            var filtro = Builders<Inmueble>.Filter.Lte(x => x.Costo, 40000);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Fecha publicación 2024-12-31 o antes
        [HttpGet("fecha-publicacion")]
        public IActionResult FechaPublicacion()
        {
            var filtro = Builders<Inmueble>.Filter.Lte(x => x.FechaPublicacion, "2024-12-31");
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Metros terreno 872 o menos
        [HttpGet("metros-terreno")]
        public IActionResult MetrosTerreno()
        {
            var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosTerreno, 872);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Metros construcción 146 o menos
        [HttpGet("metros-construccion")]
        public IActionResult MetrosConstruccion()
        {
            var filtro = Builders<Inmueble>.Filter.Lte(x => x.MetrosConstruccion, 146);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
