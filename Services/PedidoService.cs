using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

public class PedidoService
{
    private readonly CatalogoProdutosContext _context;


    public PedidoService([FromServices] CatalogoProdutosContext context){

        _context = context;
    }

    public Pedido Add( Pedido data){
         var datenow = DateTime.Now;
        data.DateCreated = datenow;
        data.DateUpdated = datenow;
        
        _context.Pedidos.Add(data);

        _context.SaveChanges();

        return data;
    }

    public List<Pedido> ListAll (){
         return  _context.Pedidos.ToList();
    }
    

    public Pedido ListOne( int id)
    {
        Pedido course = _context.Pedidos.SingleOrDefault(curse => curse.Id == id);

        if (course is null)
            return null ;
            

        return course;
    }

    public Pedido Update(int id, Pedido data)
    {
       Pedido course = _context.Pedidos.SingleOrDefault(curse => curse.Id == id); 
       if (course is null)
            return null ;


         course.Name = data.Name;
         course.Phone = data.Phone;
         course.Email  = data.Email;
         course.Adress = data.Adress;
         course.Password = data.Password;
         course.Type = data.Type;

         course.DateUpdated = DateTime.Now;
        
        _context.SaveChanges();

        return course;
    }

    public void Delete( int id){
         Pedido course = _context.Pedidos.SingleOrDefault(curse => curse.Id == id); 
       if (course is null)
            throw new Exception("Course not found") ;
        
        _context.Remove(course);
        _context.SaveChanges();
    }

}