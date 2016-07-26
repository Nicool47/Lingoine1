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
using Lingoine1.Models;
using System.Linq.Expressions;
using Lingoine1.DTO;

namespace Lingoine1.Controllers
{
    public class UserLanguageTablesController : ApiController
    {
        private LeapNullEntities db = new LeapNullEntities();

        private static readonly Expression<Func<UserLanguageTable, UserLanguageDTO>> AsUserLanguageDto =
         x => new UserLanguageDTO {
             LanguageId = x.LanguageId,
             NumOfCalls = x.NumOfCalls,
             ProficiencyLevel = x.ProficiencyLevel,
             UserEmailId = x.UserEmailId,
             Rating = x.Rating
         };


        // GET: api/UserLanguageTables
        public IQueryable<UserLanguageDTO> GetUserLanguageTables()
        {
            return db.UserLanguageTables.Select(AsUserLanguageDto);
        }

        // GET: api/UserLanguageTables/5
        [Route("{id}")]
        [ResponseType(typeof(UserLanguageDTO))]
        public async Task<IHttpActionResult> GetUserLanguage(string id)
        {
           UserLanguageDTO user =  await db.UserLanguageTables.Where(b => b.UserEmailId == id)
                .Select(AsUserLanguageDto).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PUT: api/UserLanguageTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUserLanguageTable(string id, UserLanguageTable userLanguageTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLanguageTable.UserEmailId)
            {
                return BadRequest();
            }

            db.Entry(userLanguageTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLanguageTableExists(id))
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

        // POST: api/UserLanguageTables
        [ResponseType(typeof(UserLanguageTable))]
        public async Task<IHttpActionResult> PostUserLanguageTable(UserLanguageTable userLanguageTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserLanguageTables.Add(userLanguageTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserLanguageTableExists(userLanguageTable.UserEmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userLanguageTable.UserEmailId }, userLanguageTable);
        }

        // DELETE: api/UserLanguageTables/5
        [ResponseType(typeof(UserLanguageTable))]
        public async Task<IHttpActionResult> DeleteUserLanguageTable(string id)
        {
            UserLanguageTable userLanguageTable = await db.UserLanguageTables.FindAsync(id);
            if (userLanguageTable == null)
            {
                return NotFound();
            }

            db.UserLanguageTables.Remove(userLanguageTable);
            await db.SaveChangesAsync();

            return Ok(userLanguageTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserLanguageTableExists(string id)
        {
            return db.UserLanguageTables.Count(e => e.UserEmailId == id) > 0;
        }
    }
}