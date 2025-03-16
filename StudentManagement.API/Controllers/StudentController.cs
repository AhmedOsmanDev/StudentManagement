using Microsoft.AspNetCore.Mvc;
using StudentManagement.API.Models;
using StudentManagement.API.Services;

namespace StudentManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;
    
    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_service.Get());
    }
    
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        Student student = _service.Get(id);
        
        if (student != null)
        {
            return Ok(student);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult Add([FromBody] Student student)
    {
        student.Id = _service.Add(student);
        
        if (student.Id != null)
        {
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }
        
        return BadRequest();
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] string id, [FromBody] Student student)
    {
        student.Id = id;
        
        if (_service.Update(id, student))
        {
            return Accepted(student);
        }
        
        return NotFound();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] string id)
    {
        if (_service.Delete(id))
        {
            return NoContent();
        }
        
        return NotFound();
    }
}