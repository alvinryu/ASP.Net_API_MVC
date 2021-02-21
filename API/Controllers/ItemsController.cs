using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class ItemsController : ApiController
    {
        ItemRepository itemRepo = new ItemRepository();

        public IHttpActionResult Post(Item item)
        {
            itemRepo.Create(item);
            return Ok();
        }
        
        public IHttpActionResult Delete(int id)
        {
            itemRepo.Delete(id);
            return Ok();
        }

        public IHttpActionResult PUT(int id, Item item)
        {
            itemRepo.Update(id, item);
            return Ok();
        }

        public IHttpActionResult GET()
        {
            var result = itemRepo.Get();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        public IHttpActionResult GET(int id)
        {
            var result = itemRepo.Get(id);
            return Ok(result);
        }
    }
}