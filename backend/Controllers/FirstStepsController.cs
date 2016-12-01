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
    public class FirstStepsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/FirstSteps
        public IQueryable<FirstSteps> GetFirstStepsSet()
        {
            return db.FirstStepsSet;
        }

        // GET: api/FirstSteps/5
        [ResponseType(typeof(FirstSteps))]
        public async Task<IHttpActionResult> GetFirstSteps(int id)
        {
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            if (firstSteps == null)
            {
                return NotFound();
            }

            return Ok(firstSteps);
        }

        // PUT: api/FirstSteps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFirstSteps(int id, FirstSteps firstSteps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != firstSteps.Id)
            {
                return BadRequest();
            }

            db.Entry(firstSteps).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FirstStepsExists(id))
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

        // POST: api/FirstSteps
        [ResponseType(typeof(FirstSteps))]
        public async Task<IHttpActionResult> PostFirstSteps(FirstSteps firstSteps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FirstStepsSet.Add(firstSteps);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = firstSteps.Id }, firstSteps);
        }

        // DELETE: api/FirstSteps/5
        [ResponseType(typeof(FirstSteps))]
        public async Task<IHttpActionResult> DeleteFirstSteps(int id)
        {
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            if (firstSteps == null)
            {
                return NotFound();
            }

            db.FirstStepsSet.Remove(firstSteps);
            await db.SaveChangesAsync();

            return Ok(firstSteps);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FirstStepsExists(int id)
        {
            return db.FirstStepsSet.Count(e => e.Id == id) > 0;
        }
    }
}