using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_v3.Context;
using api_v3.Entities.dict;

namespace api_v3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ProtonDbContext _context;

        public StudentsController(ProtonDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEntity>>> GetStudentEntity()
        {
            return await _context.StudentEntity.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentEntity>> GetStudentEntity(Guid id)
        {
            var studentEntity = await _context.StudentEntity.FindAsync(id);

            if (studentEntity == null)
            {
                return NotFound();
            }

            return studentEntity;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentEntity(Guid id, StudentEntity studentEntity)
        {
            if (id != studentEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentEntity>> PostStudentEntity(StudentEntity studentEntity)
        {
            _context.StudentEntity.Add(studentEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentEntity", new { id = studentEntity.Id }, studentEntity);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentEntity(Guid id)
        {
            var studentEntity = await _context.StudentEntity.FindAsync(id);
            if (studentEntity == null)
            {
                return NotFound();
            }

            _context.StudentEntity.Remove(studentEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentEntityExists(Guid id)
        {
            return _context.StudentEntity.Any(e => e.Id == id);
        }
    }
}
