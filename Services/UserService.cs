using Microsoft.AspNetCore.Mvc;
using CatalogoProdutos.Data;
using CatalogoProdutos.Models;

namespace CatalogoProdutos.Services;

public class UserService
{
    private readonly CatalogoProdutosContext _context;


    public UserService([FromServices] CatalogoProdutosContext context){

        _context = context;
    }

    public User AddNewCourse ( User data){
         var datenow = DateTime.Now;
        data.DateCreated = datenow;
        data.DateUpdated = datenow;
        
        _context.Users.Add(data);

        _context.SaveChanges();

        return data;
    }

    public List<User> ListAllCourses (){
         return  _context.Users.ToList();
    }
    

    public User ListOneCourse( int id)
    {
        User course = _context.Users.SingleOrDefault(curse => curse.Id == id);

        if (course is null)
            return null ;
            

        return course;
    }

    public User UpdateCouse(int id, User data)
    {
       User course = _context.Users.SingleOrDefault(curse => curse.Id == id); 
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

    public void DeleteCourse( int id){
         User course = _context.Users.SingleOrDefault(curse => curse.Id == id); 
       if (course is null)
            throw new Exception("Course not found") ;
        
        _context.Remove(course);
        _context.SaveChanges();
    }

}