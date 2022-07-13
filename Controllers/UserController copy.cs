using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

[ApiController]
[Route("usuarios")]
public class UserController : ControllerBase
{

  private readonly UserService _userService;

  public UserController([FromServices] UserService courseService){
    _userService = courseService;
  }
  [HttpPost]
  public ActionResult<User> PostCourse([FromBody] User data){

      var user = _userService.AddNewCourse(data);
      return CreatedAtAction(nameof(ReadAllCourses), new{id = data.Id},user);
  }

   [HttpGet]
  public ActionResult<List<User>> ReadAllCourses(){

     var courses = _userService.ListAllCourses();
        
      return Ok(courses);
  }


    [HttpGet("{id:int}")]
  public ActionResult<User> ReadOneCourse([FromRoute] int id){

      var course = _userService.ListOneCourse(id);
    
        
      return Ok(course);
  }


  [HttpPut("{id:int}")]
  public ActionResult<User> UpdateCourse([FromRoute] int id, [FromBody] User data){

      var course = _userService.UpdateCouse(id, data);
    
        
      return Ok(course);
  }


  [HttpDelete("{id:int}")]
  public ActionResult DeleteCourse([FromRoute] int id)
  {

       try
       {
         _userService.DeleteCourse(id);  
         return NoContent(); 
       }catch
       {
         return NotFound();
       }
     
  }
}
