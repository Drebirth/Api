using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;


namespace Api.Data.Collections
{
    public class Infectado
    {
        public Infectado( DateTime dataNascimnto, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimnto;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
                                    //mongo-C#Drive
                                    //Dotnet add package MongoDB.Driver
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}
