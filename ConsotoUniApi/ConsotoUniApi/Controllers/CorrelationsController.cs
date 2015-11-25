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
    public class CorrelationsController : ApiController
    {
        private ConsotoUniApiContext db = new ConsotoUniApiContext();

        // GET: api/Correlations
        public IQueryable<Correlation> GetCorrelations()
        {
            return db.Correlations;
        }

        // GET: api/Correlations/5
        [ResponseType(typeof(Correlation))]
        public IHttpActionResult GetCorrelation(int id)
        {
            Correlation correlation = db.Correlations.Find(id);
            if (correlation == null)
            {
                return NotFound();
            }

            return Ok(correlation);
        }

        // PUT: api/Correlations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCorrelation(int id, Correlation correlation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != correlation.CorrelationID)
            {
                return BadRequest();
            }

            db.Entry(correlation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorrelationExists(id))
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

        // POST: api/Correlations
        [ResponseType(typeof(Correlation))]
        public IHttpActionResult PostCorrelation(Correlation correlation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Correlations.Add(correlation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = correlation.CorrelationID }, correlation);
        }

        // DELETE: api/Correlations/5
        [ResponseType(typeof(Correlation))]
        public IHttpActionResult DeleteCorrelation(int id)
        {
            Correlation correlation = db.Correlations.Find(id);
            if (correlation == null)
            {
                return NotFound();
            }

            db.Correlations.Remove(correlation);
            db.SaveChanges();

            return Ok(correlation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CorrelationExists(int id)
        {
            return db.Correlations.Count(e => e.CorrelationID == id) > 0;
        }
    }
}