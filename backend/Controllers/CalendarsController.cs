﻿using System;
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
    public class CalendarsController : ApiController
    {
        private Model1Container db = new Model1Container();

        // GET: api/Calendars
        public IQueryable<Calendar> GetCalendarSet()
        {
            return db.CalendarSet;
        }

        // GET: api/Calendars/5
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> GetCalendar(int id)
        {
            Calendar calendar = await db.CalendarSet.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

            return Ok(calendar);
        }

        // PUT: api/Calendars/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalendar(int id, Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calendar.Id)
            {
                return BadRequest();
            }

            db.Entry(calendar).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarExists(id))
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

        // POST: api/Calendars
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> PostCalendar(Calendar calendar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CalendarSet.Add(calendar);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = calendar.Id }, calendar);
        }

        // DELETE: api/Calendars/5
        [ResponseType(typeof(Calendar))]
        public async Task<IHttpActionResult> DeleteCalendar(int id)
        {
            Calendar calendar = await db.CalendarSet.FindAsync(id);
            if (calendar == null)
            {
                return NotFound();
            }

            db.CalendarSet.Remove(calendar);
            await db.SaveChangesAsync();

            return Ok(calendar);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalendarExists(int id)
        {
            return db.CalendarSet.Count(e => e.Id == id) > 0;
        }
    }
}