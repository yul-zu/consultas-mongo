using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

namespace consultas_mongo.Controllers.Api
{
    [ApiController]
    [Route("api/nin")]
    public class NinController : Controller
    {
        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        IMongoDatabase db;
        IMongoCollection<Inmueble> collection;

        public NinController()
        {
            db = client.GetDatabase("Inmuebles");
            collection = db.GetCollection<Inmueble>("RentasVentas");
        }

        // a) Tipo distinto de "Terreno" y "Casa"
        [HttpGet("tipo")]
        public IActionResult Tipo()
        {
            var filtro = Builders<Inmueble>.Filter.Nin(x => x.Tipo, new[] { "Terreno", "Casa" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // b) Operación distinta de "Venta" y "Renta"
        [HttpGet("operacion")]
        public IActionResult Operacion()
        {
            var filtro = Builders<Inmueble>.Filter.Nin(x => x.Operacion, new[] { "Venta, Renta" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // c) Agencia distinta de 3 agencias
        [HttpGet("agencia")]
        public IActionResult Agencia()
        {
            var filtro = Builders<Inmueble>.Filter.Nin(x => x.Agencia, new[] { "López Bienes Raíces", "Inmuebles Fernández", "Propiedades Seguras" });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // d) Metros terreno distinto de 100, 200, 300
        [HttpGet("metros-terreno")]
        public IActionResult MetrosTerreno()
        {
            var filtro = Builders<Inmueble>.Filter.Nin(x => x.MetrosTerreno, new[] { 100, 200, 300 });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }

        // e) Costo distinto de 100000, 200000, 300000
        [HttpGet("costo")]
        public IActionResult Costo()
        {
            var filtro = Builders<Inmueble>.Filter.Nin(x => x.Costo, new[] { 100000, 200000, 300000 });
            var list = collection.Find(filtro).ToList();
            return Ok(list);
        }
    }
}
