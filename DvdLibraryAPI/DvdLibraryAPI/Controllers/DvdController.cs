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
    public class DvdController : ApiController
    {
        private static IDvdRepository _repo;
        static DvdController()
        {
            _repo = DvdRepositoryFactory.Create();
        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            return Ok(_repo.ReadAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Read(int id)
        {
            return Ok(_repo.Read(id));
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ReadByTitle(string title)
        {
            return Ok(_repo.ReadByTitle(title));
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ReadByDirector(string director)
        {
            return Ok(_repo.ReadByDirector(director));
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ReadByYear(string year)
        {
            return Ok(_repo.ReadByYear(year));
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ReadByRating(string rating)
        {
            return Ok(_repo.ReadByRating(rating));
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            _repo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit([FromBody] Dvd model)
        {
            if(ModelState.IsValid)
            {
                _repo.Update(model);
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Create([FromBody] Dvd model)
        {
            if (ModelState.IsValid)
            {
                var result = _repo.Create(model);
                return Ok(result);
            }
            return BadRequest("Why would you do this? Now I am very sad.");
        }
    }
}
