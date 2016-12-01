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
    public class HousingsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Housings
        public IQueryable<Housing> GetHousingSet()
        {
            return db.HousingSet;
        }

        // GET: api/Housings/5
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> GetHousing(int id)
        {
            Housing housing = await db.HousingSet.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            return Ok(housing);
        }

        // PUT: api/Housings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHousing(int id, Housing housing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != housing.Id)
            {
                return BadRequest();
            }

            db.Entry(housing).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HousingExists(id))
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

        // POST: api/Housings
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> PostHousing(Housing housing)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HousingSet.Add(housing);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = housing.Id }, housing);
        }

        // DELETE: api/Housings/5
        [ResponseType(typeof(Housing))]
        public async Task<IHttpActionResult> DeleteHousing(int id)
        {
            Housing housing = await db.HousingSet.FindAsync(id);
            if (housing == null)
            {
                return NotFound();
            }

            db.HousingSet.Remove(housing);
            await db.SaveChangesAsync();

            return Ok(housing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HousingExists(int id)
        {
            return db.HousingSet.Count(e => e.Id == id) > 0;
        }
    }
}