using Mapster;
using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Services;

public class ProdutoService
{
    private readonly CatalogoProdutosContext _context;


    public ProdutoService([FromServices] CatalogoProdutosContext context){

        _context = context;
    }

      public List<ProdutoResponseDTO> ListAll (){


         return  _context.Produtos.Include(produto => produto.Categoria)
            .ProjectToType<ProdutoResponseDTO>()
            .ToList();
    }

    public ProdutoResponseDTO ListOne( int id)
    {
        var produto = _context.Produtos
            .AsNoTracking()
            .Include(produto => produto.Categoria)
            .SingleOrDefault(produto => produto.Id == id);

        if (produto is null)
        {
            throw new Exception("Produto não encontrado");
        }

        //Copiar (mapear) de Usuario para UsuarioResponseDto
        var produtoDto = produto.Adapt<ProdutoResponseDTO>();
        return produtoDto;
    }

      public ProdutoResponseDTO Add( ProdutoCreateUpdateDTO data){
          
        var produto = data.Adapt<Produto>();
      
        //  var datenow = DateTime.Now;
        // produto.DateCreated = datenow;
        // produto.DateUpdated = datenow;
        
        _context.Produtos.Add(produto);

        _context.SaveChanges();

        var produtoDto = produto.Adapt<ProdutoResponseDTO>();
        return produtoDto;
    }

    public ProdutoResponseDTO Update(int id, ProdutoCreateUpdateDTO data)
    {
       var produto = _context.Produtos
       .SingleOrDefault(item => item.Id == id); 


         if (produto is null)
        {
            throw new Exception("Produto não encontrado");
        }

        data.Adapt(produto);
        
        _context.SaveChanges();

         var produtoDto = produto.Adapt<ProdutoResponseDTO>();
        return produtoDto;
    }

    public void Delete( int id){
         Produto item = _context.Produtos.SingleOrDefault(item => item.Id == id); 
       if (item is null)
            throw new Exception("Produto não encontrado") ;
        
        _context.Remove(item);
        _context.SaveChanges();
    }

}