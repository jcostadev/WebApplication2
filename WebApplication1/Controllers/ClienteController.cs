using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Mongo;

namespace WebApplication1.Controllers {
    public class ClienteController : ApiController
    {
        Repository _repository;        

        public ClienteController() 
        {
           _repository = new Repository();               
        }
                
       public void Post([FromBody]Cliente cliente) 
       {
           _repository.Add(cliente);        
       }          

       public Cliente Get(int id) 
       {
            var cliente = _repository.Get(id);

            if (cliente != null) return cliente;
            else return null;
       }

        public IEnumerable<Cliente> GetAll()
        {
            return _repository.GetAll();
        }

        // PUT api/cliente/5
       public void Put(int id, [FromBody]Cliente cliente)
       {
            _repository.Update(cliente, id);
       }
           
       [HttpPatch]
       public void Patch(int id, [FromBody]Cliente cliente)
       {

       } 
           
        // DELETE api/cliente/5
       public void Delete([FromBody]Cliente cliente, int id)
       {
            _repository.Delete(cliente, id);            
       }      

    }
}