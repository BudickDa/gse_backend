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
    public class ChecklistsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Checklists
        public IQueryable<Checklist> GetChecklistSet()
        {
            return db.ChecklistSet;
        }

        // GET: api/Checklists/5
        [ResponseType(typeof(Checklist))]
        public async Task<IHttpActionResult> GetChecklist(int id)
        {
            Checklist checklist = await db.ChecklistSet.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            return Ok(checklist);
        }

        // PUT: api/Checklists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChecklist(int id, Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != checklist.Id)
            {
                return BadRequest();
            }

            db.Entry(checklist).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistExists(id))
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

        // POST: api/Checklists
        [ResponseType(typeof(Checklist))]
        public async Task<IHttpActionResult> PostChecklist(Checklist checklist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChecklistSet.Add(checklist);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = checklist.Id }, checklist);
        }

        // DELETE: api/Checklists/5
        [ResponseType(typeof(Checklist))]
        public async Task<IHttpActionResult> DeleteChecklist(int id)
        {
            Checklist checklist = await db.ChecklistSet.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            db.ChecklistSet.Remove(checklist);
            await db.SaveChangesAsync();

            return Ok(checklist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChecklistExists(int id)
        {
            return db.ChecklistSet.Count(e => e.Id == id) > 0;
        }
    }
}