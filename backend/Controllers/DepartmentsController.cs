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
    public class DepartmentsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Departments
        public IQueryable<Departments> GetDepartmentsSet()
        {
            return db.DepartmentsSet;
        }

        // GET: api/Departments/5
        [ResponseType(typeof(Departments))]
        public async Task<IHttpActionResult> GetDepartments(int id)
        {
            Departments departments = await db.DepartmentsSet.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }

            return Ok(departments);
        }

        // PUT: api/Departments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDepartments(int id, Departments departments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departments.Id)
            {
                return BadRequest();
            }

            db.Entry(departments).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsExists(id))
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

        // POST: api/Departments
        [ResponseType(typeof(Departments))]
        public async Task<IHttpActionResult> PostDepartments(Departments departments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DepartmentsSet.Add(departments);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = departments.Id }, departments);
        }

        // DELETE: api/Departments/5
        [ResponseType(typeof(Departments))]
        public async Task<IHttpActionResult> DeleteDepartments(int id)
        {
            Departments departments = await db.DepartmentsSet.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }

            db.DepartmentsSet.Remove(departments);
            await db.SaveChangesAsync();

            return Ok(departments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentsExists(int id)
        {
            return db.DepartmentsSet.Count(e => e.Id == id) > 0;
        }
    }
}