using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

public class ProdutoService
{
    private readonly CatalogoProdutosContext _context;


    public ProdutoService([FromServices] CatalogoProdutosContext context){

        _context = context;
    }

    public Produto Add( Produto data){
         var datenow = DateTime.Now;
        data.DateCreated = datenow;
        data.DateUpdated = datenow;
        
        _context.Produtos.Add(data);

        _context.SaveChanges();

        return data;
    }

    public List<Produto> ListAll (){
         return  _context.Produtos.ToList();
    }
    

    public Produto ListOne( int id)
    {
        Produto course = _context.Produtos.SingleOrDefault(curse => curse.Id == id);

        if (course is null)
            return null ;
            

        return course;
    }

    public Produto Update(int id, Produto data)
    {
       Produto course = _context.Produtos.SingleOrDefault(curse => curse.Id == id); 
       if (course is null)
            return null ;
        
        _context.SaveChanges();

        return course;
    }

    public void Delete( int id){
         Produto item = _context.Produtos.SingleOrDefault(item => item.Id == id); 
       if (item is null)
            throw new Exception("Course not found") ;
        
        _context.Remove(item);
        _context.SaveChanges();
    }

}