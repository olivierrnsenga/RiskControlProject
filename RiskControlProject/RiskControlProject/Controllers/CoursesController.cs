using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskControlProject.Models;

namespace RiskControlProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly CrudContext _dbContext;

    public CoursesController(CrudContext dbContext)
    {
        _dbContext = dbContext;
    }


    [HttpGet("/GetCourses")]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        return await _dbContext.Courses.ToListAsync();
    }


    [HttpGet("{id}/GetCourses")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _dbContext.Courses.FindAsync(id);

        if (course != null) return course;
        return NotFound();
    }


    [HttpPost("/PostCourse")]
    public async Task<ActionResult<IEnumerable<Course>>> PostCourse(Course course)
    {
        _dbContext.Courses.Add(course);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    [HttpDelete("{id}/DeleteCourse")]
    public async Task<ActionResult<IEnumerable<Course>>> DeleteClassRoom(int id)
    {
        var course = await _dbContext.Courses.FindAsync(id);
        if (course == null)
            return NotFound();

        _dbContext.Courses.Remove(course);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}/PutCourse")]
    public async Task<ActionResult<IEnumerable<Course>>> PutClassRoom(int id, Course course)
    {
        if (id != course.Id) return BadRequest();
        _dbContext.Entry(course).State = EntityState.Modified;
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CourseExists(id))
                return NotFound();
            throw;
        }

        return NoContent();
    }

    private bool CourseExists(int id)
    {
        return (_dbContext.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}