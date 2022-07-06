using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

public class User
{
    [Required]
    public int Id { get; set; }
    [Required]  
    [Column(TypeName ="varchar(255)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName ="varchar(255)")]
    public string Phone { get; set; }
    [Required]
    [Column(TypeName ="text")]
    public string Adress { get; set; }
    [Required]
    [Column(TypeName ="varchar(255)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName ="varchar(255)")]
    public string Password { get; set; }
     [Required]
    [Column(TypeName ="varchar(255)")]
    public string Type { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }


   
    
}
