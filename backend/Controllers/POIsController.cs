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
    public class POIsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/POIs
        public IQueryable<POI> GetPOISet()
        {
            return db.POISet;
        }

        // GET: api/POIs/5
        [ResponseType(typeof(POI))]
        public async Task<IHttpActionResult> GetPOI(int id)
        {
            POI pOI = await db.POISet.FindAsync(id);
            if (pOI == null)
            {
                return NotFound();
            }

            return Ok(pOI);
        }

        // PUT: api/POIs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPOI(int id, POI pOI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pOI.Id)
            {
                return BadRequest();
            }

            db.Entry(pOI).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!POIExists(id))
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

        // POST: api/POIs
        [ResponseType(typeof(POI))]
        public async Task<IHttpActionResult> PostPOI(POI pOI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.POISet.Add(pOI);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pOI.Id }, pOI);
        }

        // DELETE: api/POIs/5
        [ResponseType(typeof(POI))]
        public async Task<IHttpActionResult> DeletePOI(int id)
        {
            POI pOI = await db.POISet.FindAsync(id);
            if (pOI == null)
            {
                return NotFound();
            }

            db.POISet.Remove(pOI);
            await db.SaveChangesAsync();

            return Ok(pOI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool POIExists(int id)
        {
            return db.POISet.Count(e => e.Id == id) > 0;
        }
    }
}