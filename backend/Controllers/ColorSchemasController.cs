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
    public class ColorSchemasController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/ColorSchemas
        public IQueryable<ColorSchema> GetColorSchemaSet()
        {
            return db.ColorSchemaSet;
        }

        // GET: api/ColorSchemas/5
        [ResponseType(typeof(ColorSchema))]
        public async Task<IHttpActionResult> GetColorSchema(int id)
        {
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            if (colorSchema == null)
            {
                return NotFound();
            }

            return Ok(colorSchema);
        }

        // PUT: api/ColorSchemas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutColorSchema(int id, ColorSchema colorSchema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorSchema.Id)
            {
                return BadRequest();
            }

            db.Entry(colorSchema).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorSchemaExists(id))
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

        // POST: api/ColorSchemas
        [ResponseType(typeof(ColorSchema))]
        public async Task<IHttpActionResult> PostColorSchema(ColorSchema colorSchema)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorSchemaSet.Add(colorSchema);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = colorSchema.Id }, colorSchema);
        }

        // DELETE: api/ColorSchemas/5
        [ResponseType(typeof(ColorSchema))]
        public async Task<IHttpActionResult> DeleteColorSchema(int id)
        {
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            if (colorSchema == null)
            {
                return NotFound();
            }

            db.ColorSchemaSet.Remove(colorSchema);
            await db.SaveChangesAsync();

            return Ok(colorSchema);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorSchemaExists(int id)
        {
            return db.ColorSchemaSet.Count(e => e.Id == id) > 0;
        }
    }
}