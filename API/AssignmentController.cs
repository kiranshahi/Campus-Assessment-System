﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly CASContext _context;

        public AssignmentController(CASContext context)
        {
            _context = context;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignment(int classId)
        {
            return await _context.Assignments.FromSql($"EXECUTE dbo.GetAssignmentByClassID @ClassId = {classId}").ToListAsync();
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Assignment>> GetAssignmentDetail(int id)
        {
            var assignmentDetail = await _context.Assignments.FindAsync(id);
            if (assignmentDetail == null)
            {
                return NotFound();
            }
            return assignmentDetail;
        }

        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, Assignment assignmentDetails)
        {
            if (id != assignmentDetails.ID)
            {
                return BadRequest();
            }

            _context.Entry(assignmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentDetailExists(id))
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

        // POST: api/Assignment
        [HttpPost]
        public int PostAssignmentDetail(Assignment assignmentDetail)
        {
            return _context.Database.ExecuteSqlCommand($"dbo.AddAssignment @AssinmentID = {assignmentDetail.ID}, @title = {assignmentDetail.Title}, @instructions = {assignmentDetail.Instructions}, @attachment = {assignmentDetail.Attachment}, @duedate ={assignmentDetail.DueDate}, @classid ={assignmentDetail.ClassID}");
        }

        // DELETE: api/Assignment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assignment>> DeleteAssignmentDetail(int id)
        {
            var assignmentDetail = await _context.Assignments.FindAsync(id);
            if (assignmentDetail == null)
            {
                return NotFound();
            }
            _context.Assignments.Remove(assignmentDetail);
            await _context.SaveChangesAsync();
            return assignmentDetail;
        }

        private bool AssignmentDetailExists(int id)
        {
            return _context.Assignments.Any(e => e.ID == id);
        }
    }
}
