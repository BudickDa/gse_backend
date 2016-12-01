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
    public class FAQsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/FAQs
        public IQueryable<FAQ> GetFAQSet()
        {
            return db.FAQSet;
        }

        // GET: api/FAQs/5
        [ResponseType(typeof(FAQ))]
        public async Task<IHttpActionResult> GetFAQ(int id)
        {
            FAQ fAQ = await db.FAQSet.FindAsync(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return Ok(fAQ);
        }

        // PUT: api/FAQs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFAQ(int id, FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fAQ.Id)
            {
                return BadRequest();
            }

            db.Entry(fAQ).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAQExists(id))
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

        // POST: api/FAQs
        [ResponseType(typeof(FAQ))]
        public async Task<IHttpActionResult> PostFAQ(FAQ fAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FAQSet.Add(fAQ);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = fAQ.Id }, fAQ);
        }

        // DELETE: api/FAQs/5
        [ResponseType(typeof(FAQ))]
        public async Task<IHttpActionResult> DeleteFAQ(int id)
        {
            FAQ fAQ = await db.FAQSet.FindAsync(id);
            if (fAQ == null)
            {
                return NotFound();
            }

            db.FAQSet.Remove(fAQ);
            await db.SaveChangesAsync();

            return Ok(fAQ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FAQExists(int id)
        {
            return db.FAQSet.Count(e => e.Id == id) > 0;
        }
    }
}