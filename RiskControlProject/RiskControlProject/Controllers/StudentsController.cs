using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RiskControlProject.Models;

namespace RiskControlProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly CrudContext _dbContext;

    public StudentsController(CrudContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("GetStudents")]
    public string GetStudents()
    {

        return JsonConvert.SerializeObject(_dbContext.Students.ToListAsync());
    }


    [HttpGet("{id}/GetStudent")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student != null) return student;
        return NotFound();
    }


    [HttpPost("PostStudent")]
    public async Task<ActionResult<IEnumerable<Student>>> PostStudent(Student student)
    {
        _dbContext.Students.Add(student);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    [HttpDelete("{id}/DeleteStudent")]
    public async Task<ActionResult<IEnumerable<Course>>> DeleteClassRoom(int id)
    {
        var student = await _dbContext.Students.FindAsync(id);
        if (student == null)
            return NotFound();

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}/PutStudent")]
    public async Task<ActionResult<IEnumerable<Student>>> PutClassRoom(int id, Student student)
    {
        if (id != student.Id) return BadRequest();
        _dbContext.Entry(student).State = EntityState.Modified;
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    private bool StudentExists(int id)
    {
        return (_dbContext.Students?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}