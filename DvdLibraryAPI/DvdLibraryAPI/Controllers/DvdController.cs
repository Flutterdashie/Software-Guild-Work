using DvdLibraryAPI.Models;
using DvdLibraryAPI.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibraryAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {
        private static IDvdRepository _repo;
        static DvdController()
        {

        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = new DvdLibraryEntities();
            return Ok(repo.Dvds);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit([FromBody] Dvd model)
        {
            if(ModelState.IsValid)
            {

            }

        }
    }
}
