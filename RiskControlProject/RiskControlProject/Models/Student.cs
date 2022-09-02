namespace RiskControlProject.Models;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CourseId { get; set; }
    public int ClassId { get; set; }
}