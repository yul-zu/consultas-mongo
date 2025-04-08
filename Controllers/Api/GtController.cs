using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/gt")]
    public class GtController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public GtController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Costo mayor a 1,500,000
        [HttpGet("mayor-costo")]
        public IActionResult MayorCosto()
        {
            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Costo, 1500000);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Más de 2 baños
        [HttpGet("mayor-baños")]
        public IActionResult MayorBanos()
        {
            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Banios, 2);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Metros terreno mayor a 500m
        [HttpGet("mayor-terreno")]
        public IActionResult MayorTerreno()
        {
            var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosTerreno, 500);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Metros construcción mayor a 600m
        [HttpGet("mayor-construccion")]
        public IActionResult MayorConstruccion()
        {
            var filtro = Builders<Inmueble>.Filter.Gt(x => x.MetrosConstruccion, 600);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Más de 2 pisos
        [HttpGet("mayor-pisos")]
        public IActionResult MayorPisos()
        {
            var filtro = Builders<Inmueble>.Filter.Gt(x => x.Pisos, 2);
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}


