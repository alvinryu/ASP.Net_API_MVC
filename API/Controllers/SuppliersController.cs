using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace API.Controllers
{
    public class SuppliersController : ApiController
    {
        SupplierRepository sp = new SupplierRepository();

        public IHttpActionResult Post(Supplier supplier)
        {
            var create = sp.Create(supplier);

            if(create > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            var delete = sp.Delete(id);
            
            if(delete > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult PUT(int id, Supplier supplier)
        {
            var update = sp.Update(id, supplier);
            
            if (update > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        public IHttpActionResult GET()
        {
            var result = sp.Get();

            if(result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        public async Task<IHttpActionResult> GET(int id)
        {
            var result = await sp.Get(id);
            
            if(result != null)
            {
                if(result.Count() > 0)
                {
                    return Ok(result);
                }

                return Content(HttpStatusCode.BadRequest, "Data Not Found");
            }

            return BadRequest();
        }
    }
}