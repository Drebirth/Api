using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MongoDB.Driver;
using Api.Data.Collections;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Infectados2Controller : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public Infectados2Controller(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }
        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);

            return StatusCode(201, "Infectado adicionado com sucesso!");
        }
       
        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }

        [HttpPut("{id:length(24)}")]
        public ActionResult AtualizazInfectado([FromBody] InfectadoDto dto, string id)
        {
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == id), Builders<Infectado>.Update.Set(
                "Sexo", dto.Sexo));

            return Ok("Atualizado com sucesso!");
        }

        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == id));

            return Ok("Deletado com sucesso!");
        }

    }
}
