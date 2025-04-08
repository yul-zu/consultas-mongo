using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/gte")]
    public class GteController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public GteController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Metros terreno 553 o más
        [HttpGet("terreno-mayor-igual")]
        public IActionResult TerrenoMayorIgual()
        {
            var filtro = Builders<Inmueble>.Filter.Gte(x => x.MetrosTerreno, 553);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Metros construcción 322 o más
        [HttpGet("construccion-mayor-igual")]
        public IActionResult ConstruccionMayorIgual()
        {
            var filtro = Builders<Inmueble>.Filter.Gte(x => x.MetrosConstruccion, 322);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Pisos 3 o más
        [HttpGet("pisos-mayor-igual")]
        public IActionResult PisosMayorIgual()
        {
            var filtro = Builders<Inmueble>.Filter.Gte(x => x.Pisos, 3);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Costo 7,000 o más
        [HttpGet("costo-mayor-igual")]
        public IActionResult CostoMayorIgual()
        {
            var filtro = Builders<Inmueble>.Filter.Gte(x => x.Costo, 7000);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Fecha de publicación "2025-01-04" o posterior
        [HttpGet("fecha-mayor-igual")]
        public IActionResult FechaMayorIgual()
        {
            var filtro = Builders<Inmueble>.Filter.Gte(x => x.FechaPublicacion, "2025-01-04");
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
