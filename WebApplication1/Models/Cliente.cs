using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models 
{
    public class Cliente 
    {
        [BsonElement("_id")]
        public int ID { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public static explicit operator UpdateDefinition<object>(Cliente v) {
            throw new NotImplementedException();
        }

        public static explicit operator Cliente(FilterDefinition<Cliente> v) {
            throw new NotImplementedException();
        }
    }
}