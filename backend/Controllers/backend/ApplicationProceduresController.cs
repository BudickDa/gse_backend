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
    public class ApplicationProceduresController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: ApplicationProcedures
        public async Task<ActionResult> Index()
        {
            return View(await db.ApplicationProcedureSet.ToListAsync());
        }

        // GET: ApplicationProcedures/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            if (applicationProcedure == null)
            {
                return HttpNotFound();
            }
            return View(applicationProcedure);
        }

        // GET: ApplicationProcedures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationProcedures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,deathline,link,information")] ApplicationProcedure applicationProcedure)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationProcedureSet.Add(applicationProcedure);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationProcedure);
        }

        // GET: ApplicationProcedures/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            if (applicationProcedure == null)
            {
                return HttpNotFound();
            }
            return View(applicationProcedure);
        }

        // POST: ApplicationProcedures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,deathline,link,information")] ApplicationProcedure applicationProcedure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationProcedure).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationProcedure);
        }

        // GET: ApplicationProcedures/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            if (applicationProcedure == null)
            {
                return HttpNotFound();
            }
            return View(applicationProcedure);
        }

        // POST: ApplicationProcedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationProcedure applicationProcedure = await db.ApplicationProcedureSet.FindAsync(id);
            db.ApplicationProcedureSet.Remove(applicationProcedure);
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
