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
    public class ApplicationProceduresController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/ApplicationProcedures
        public IQueryable<ApplicationProcedure> GetApplicationProcedureSet()
        {
            return db.ApplicationProcedureSet;
        }

        // GET: api/ApplicationProcedures/5
        [ResponseType(typeof(ApplicationProcedure))]
        public async Task<IHttpActionResult> GetApplicationProcedure(int id)
        {
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            if (applicationProcedure == null)
            {
                return NotFound();
            }

            return Ok(applicationProcedure);
        }

        // PUT: api/ApplicationProcedures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationProcedure(int id, ApplicationProcedure applicationProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationProcedure.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationProcedure).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationProcedureExists(id))
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

        // POST: api/ApplicationProcedures
        [ResponseType(typeof(ApplicationProcedure))]
        public async Task<IHttpActionResult> PostApplicationProcedure(ApplicationProcedure applicationProcedure)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ApplicationProcedureSet.Add(applicationProcedure);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = applicationProcedure.Id }, applicationProcedure);
        }

        // DELETE: api/ApplicationProcedures/5
        [ResponseType(typeof(ApplicationProcedure))]
        public async Task<IHttpActionResult> DeleteApplicationProcedure(int id)
        {
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            if (applicationProcedure == null)
            {
                return NotFound();
            }

            db.ApplicationProcedureSet.Remove(applicationProcedure);
            await db.SaveChangesAsync();

            return Ok(applicationProcedure);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationProcedureExists(int id)
        {
            return db.ApplicationProcedureSet.Count(e => e.Id == id) > 0;
        }
    }
}