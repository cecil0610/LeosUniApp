using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ConsotoUniApi.Models;

namespace ConsotoUniApi.Controllers
{
    public class CourseWorksController : ApiController
    {
        private ConsotoUniApiContext db = new ConsotoUniApiContext();

        // GET: api/CourseWorks
        public IQueryable<CourseWork> GetCourseWorks()
        {
            return db.CourseWorks;
        }

        // GET: api/CourseWorks/5
        [ResponseType(typeof(CourseWork))]
        public IHttpActionResult GetCourseWork(int id)
        {
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return NotFound();
            }

            return Ok(courseWork);
        }

        // PUT: api/CourseWorks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseWork(int id, CourseWork courseWork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseWork.CourseWorkID)
            {
                return BadRequest();
            }

            db.Entry(courseWork).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseWorkExists(id))
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

        // POST: api/CourseWorks
        [ResponseType(typeof(CourseWork))]
        public IHttpActionResult PostCourseWork(CourseWork courseWork)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseWorks.Add(courseWork);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = courseWork.CourseWorkID }, courseWork);
        }

        // DELETE: api/CourseWorks/5
        [ResponseType(typeof(CourseWork))]
        public IHttpActionResult DeleteCourseWork(int id)
        {
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return NotFound();
            }

            db.CourseWorks.Remove(courseWork);
            db.SaveChanges();

            return Ok(courseWork);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseWorkExists(int id)
        {
            return db.CourseWorks.Count(e => e.CourseWorkID == id) > 0;
        }
    }
}