using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

[ApiController]
[Route("categorias")]
public class CategoriaController : ControllerBase
{

  private readonly CategoriaService _categoriaService;

  public CategoriaController([FromServices] CategoriaService categoriaService){
    _categoriaService = categoriaService;
  }
  [HttpPost]
  public ActionResult<CategoriaResponseDto> Post([FromBody] CategoriaCreateUpdateDTO data){
       Console.WriteLine(data);
      var categoria = _categoriaService.Add(data);
      return CreatedAtAction(nameof(Get), new{id = categoria.Id}, categoria);
  }

   [HttpGet]
  public ActionResult<List<CategoriaResponseDto>> Get(){

     var categorias = _categoriaService.ListAll();
        
      return Ok(categorias);
  }


    [HttpGet("{id:int}")]
  public ActionResult<Categoria> Read([FromRoute] int id){

      var categoria = _categoriaService.ListOne(id);
    
        
      return Ok(categoria);
  }


  [HttpPut("{id:int}")]
  public ActionResult<Categoria> Up([FromRoute] int id, [FromBody] CategoriaCreateUpdateDTO data){

      var categoria = _categoriaService.Update(id, data);
    
        
      return Ok(categoria);
  }


  [HttpDelete("{id:int}")]
  public ActionResult Del([FromRoute] int id)
  {

       try
       {
         _categoriaService.Delete(id);  
         return NoContent(); 
       }catch
       {
         return NotFound();
       }
     
  }
}
