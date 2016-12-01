using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using backend.Models;

namespace backend.Controllers
{
    public class UniversitiesController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Universities
        public IQueryable<University> GetUniversitySet()
        {
            return db.UniversitySet;
        }

        // GET: api/Universities/5
        [ResponseType(typeof(University))]
        public async Task<IHttpActionResult> GetUniversity(int id)
        {
            University university = await db.UniversitySet.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            return Ok(university);
        }

        // PUT: api/Universities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUniversity(int id, University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != university.Id)
            {
                return BadRequest();
            }

            db.Entry(university).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Universities
        [ResponseType(typeof(University))]
        public async Task<IHttpActionResult> PostUniversity(University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UniversitySet.Add(university);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = university.Id }, university);
        }

        // DELETE: api/Universities/5
        [ResponseType(typeof(University))]
        public async Task<IHttpActionResult> DeleteUniversity(int id)
        {
            University university = await db.UniversitySet.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            db.UniversitySet.Remove(university);
            await db.SaveChangesAsync();

            return Ok(university);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UniversityExists(int id)
        {
            return db.UniversitySet.Count(e => e.Id == id) > 0;
        }
    }
}