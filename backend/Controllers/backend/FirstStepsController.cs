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
    public class FirstStepsController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: FirstSteps
        public async Task<ActionResult> Index()
        {
            return View(await db.FirstStepsSet.ToListAsync());
        }

        // GET: FirstSteps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            if (firstSteps == null)
            {
                return HttpNotFound();
            }
            return View(firstSteps);
        }

        // GET: FirstSteps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirstSteps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,information,link,description")] FirstSteps firstSteps)
        {
            if (ModelState.IsValid)
            {
                db.FirstStepsSet.Add(firstSteps);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(firstSteps);
        }

        // GET: FirstSteps/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            if (firstSteps == null)
            {
                return HttpNotFound();
            }
            return View(firstSteps);
        }

        // POST: FirstSteps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,information,link,description")] FirstSteps firstSteps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstSteps).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(firstSteps);
        }

        // GET: FirstSteps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            if (firstSteps == null)
            {
                return HttpNotFound();
            }
            return View(firstSteps);
        }

        // POST: FirstSteps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FirstSteps firstSteps = await db.FirstStepsSet.FindAsync(id);
            db.FirstStepsSet.Remove(firstSteps);
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
