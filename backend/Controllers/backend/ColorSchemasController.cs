using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using backend.Models;

namespace backend.Controllers.backend
{
    public class ColorSchemasController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ColorSchemas
        public async Task<ActionResult> Index()
        {
            return View(await db.ColorSchemaSet.ToListAsync());
        }

        // GET: ColorSchemas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            if (colorSchema == null)
            {
                return HttpNotFound();
            }
            return View(colorSchema);
        }

        // GET: ColorSchemas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ColorSchemas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,colorOne,colorTwo,colorThree,colorFive,colorFour")] ColorSchema colorSchema)
        {
            if (ModelState.IsValid)
            {
                db.ColorSchemaSet.Add(colorSchema);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(colorSchema);
        }

        // GET: ColorSchemas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            if (colorSchema == null)
            {
                return HttpNotFound();
            }
            return View(colorSchema);
        }

        // POST: ColorSchemas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,colorOne,colorTwo,colorThree,colorFive,colorFour")] ColorSchema colorSchema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colorSchema).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(colorSchema);
        }

        // GET: ColorSchemas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            if (colorSchema == null)
            {
                return HttpNotFound();
            }
            return View(colorSchema);
        }

        // POST: ColorSchemas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ColorSchema colorSchema = await db.ColorSchemaSet.FindAsync(id);
            db.ColorSchemaSet.Remove(colorSchema);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
