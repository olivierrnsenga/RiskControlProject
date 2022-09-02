using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskControlProject.Models;

namespace RiskControlProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomsController : ControllerBase
{
    private readonly CrudContext _dbContext;

    public ClassroomsController(CrudContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("GetClassRooms")]
    public async Task<ActionResult<IEnumerable<Classroom>>> GetClassRooms()
    {
        return await _dbContext.Classrooms.ToListAsync();
    }


    [HttpGet("{id}/GetClassRoom")]
    public async Task<ActionResult<Classroom>> GetClassRoom(int id)
    {
        var classroom = await _dbContext.Classrooms.FindAsync(id);

        if (classroom != null) return classroom;
        return NotFound();
    }


    [HttpPost("PostClassRoom")]
    public async Task<ActionResult<IEnumerable<Classroom>>> PostClassRoom(Classroom classroom)
    {
        _dbContext.Classrooms.Add(classroom);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetClassRoom), new { id = classroom.Id }, classroom);
    }

    [HttpDelete("{id}/DeleteClassRoom")]
    public async Task<ActionResult<IEnumerable<Classroom>>> DeleteClassRoom(int id)
    {
        var classroom = await _dbContext.Classrooms.FindAsync(id);
        if (classroom == null)
            return NotFound();

        _dbContext.Classrooms.Remove(classroom);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}/PutClassRoom")]
    public async Task<ActionResult<IEnumerable<Classroom>>> PutClassRoom(int id, Classroom classroom)
    {
        if (id != classroom.Id) return BadRequest();
        _dbContext.Entry(classroom).State = EntityState.Modified;
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClassroomExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    private bool ClassroomExists(int id)
    {
        return (_dbContext.Classrooms?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}