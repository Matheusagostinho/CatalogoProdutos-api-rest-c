using Mapster;
using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Services;

public class CategoriaService
{
    private readonly CatalogoProdutosContext _context;


    public CategoriaService([FromServices] CatalogoProdutosContext context){

        _context = context;
    }

      public List<CategoriaResponseDto> ListAll (){


         return  _context.Categorias
            .ProjectToType<CategoriaResponseDto>()
            .ToList();
    }

    public CategoriaResponseDto ListOne( int id)
    {
        var categoria = _context.Categorias
            .AsNoTracking()
            .SingleOrDefault(categoria => categoria.Id == id);
            

        if (categoria is null)
        {
            throw new Exception("Produto não encontrado");
        }

        //Copiar (mapear) de Usuario para UsuarioResponseDto
        var categoriaDto = categoria.Adapt<CategoriaResponseDto>();
        return categoriaDto;
    }

      public CategoriaResponseDto Add( CategoriaCreateUpdateDTO data){
          
        var categoria = data.Adapt<Categoria>();
      
        //  var datenow = DateTime.Now;
        // produto.DateCreated = datenow;
        // produto.DateUpdated = datenow;
        
        _context.Categorias.Add(categoria);

        _context.SaveChanges();

        var categoriaDto = categoria.Adapt<CategoriaResponseDto>();
        return categoriaDto;
    }

    public CategoriaResponseDto Update(int id, CategoriaCreateUpdateDTO data)
    {
       var categoria = _context.Categorias
       .SingleOrDefault(item => item.Id == id); 


         if (categoria is null)
        {
            throw new Exception("Categoria não encontrado");
        }

        data.Adapt(categoria);
        
        _context.SaveChanges();

         var categoriaDto = categoria.Adapt<CategoriaResponseDto>();
        return categoriaDto;
    }

    public void Delete( int id){
         Categoria item = _context.Categorias.SingleOrDefault(item => item.Id == id); 
       if (item is null)
            throw new Exception("Produto não encontrado") ;
        
        _context.Remove(item);
        _context.SaveChanges();
    }

}