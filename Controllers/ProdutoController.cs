using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services;

namespace CatalogoProdutos.Controllers;

[ApiController]
[Route("produtos")]
public class ProdutoController : ControllerBase
{

  private readonly ProdutoService _produtoService;

  public ProdutoController([FromServices] ProdutoService produtoService){
    _produtoService = produtoService;
  }
  [HttpPost]
  public ActionResult<ProdutoResponseDTO> Post([FromBody] ProdutoCreateUpdateDTO data){
       Console.WriteLine(data);
      var produto = _produtoService.Add(data);
      return CreatedAtAction(nameof(Get), new{id = produto.Id}, produto);
  }

   [HttpGet]
  public ActionResult<List<ProdutoResponseDTO>> Get(){

     var produtos = _produtoService.ListAll();
        
      return Ok(produtos);
  }


    [HttpGet("{id:int}")]
  public ActionResult<Produto> Read([FromRoute] int id){

      var produto = _produtoService.ListOne(id);
    
        
      return Ok(produto);
  }


  [HttpPut("{id:int}")]
  public ActionResult<Produto> Up([FromRoute] int id, [FromBody] ProdutoCreateUpdateDTO data){

      var produto = _produtoService.Update(id, data);
    
        
      return Ok(produto);
  }


  [HttpDelete("{id:int}")]
  public ActionResult DeleteCourse([FromRoute] int id)
  {

       try
       {
         _produtoService.Delete(id);  
         return NoContent(); 
       }catch
       {
         return NotFound();
       }
     
  }
}
