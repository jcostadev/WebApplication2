using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WebApplication1.Models;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Misc;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApplication1.Mongo
{
    public class Repository
    {   
       protected static IMongoClient _client;
       protected static IMongoDatabase _database;
       protected static IMongoCollection<Cliente> _collection;

       public Repository()
       {
           _client = new MongoClient();
           _database = _client.GetDatabase("Pessoa");
           _collection = _database.GetCollection<Cliente>("Cliente");                                                
       }

      /* public Task<HttpResponseMessage> PatchAsJsonAsync<T>(this HttpClient client, string requestUri, T value) 
       {
            Ensure.Argument.NotNull(client, "client");
            Ensure.Argument.NotNullOrEmpty(requestUri, "requestUri");
            Ensure.Argument.NotNull(value, "value");

            var content = new ObjectContent<T>(value, new JsonMediaTypeFormatter());
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri) { Content = content };

            return client.SendAsync(request);
       }*/


       public void Add(Cliente entity) 
       {            
           _collection.InsertOne(entity);
       }

       public Cliente Get(int id) 
       {
           return _collection.Find<Cliente>(x => x.ID == id).First();
       }

       public void Delete(Cliente cliente, int id) 
       {
            var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);

            _collection.DeleteOne(filter);    
            
                   
       }
      
        public void Patch(Cliente cliente, int id) 
        {
            var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);
            var c = (Cliente)filter;            
            
        }

       /*[HttpPatch]
       public Cliente UpdateDetailViaPatch(int id, [FromBody] string LastName)
       {
           var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);           
       }
       passar um ID*/

        

       public void Update(Cliente cliente, int id) 
       {
           var filter = Builders<Cliente>.Filter.Where(e => e.ID == id);

           var update = _collection.ReplaceOne(filter, cliente);                
       }

        public IEnumerable<Cliente> GetAll()
        {
            var filter = new JsonFilterDefinition<Cliente>("{}");
            
            var t = _collection.Find<Cliente>(filter);

             var data = t.ToList<Cliente>();

            return data;
        }

        
    }
}