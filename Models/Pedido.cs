using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class Pedido
    {
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime DateCreated { get; set; }
    [Required]
    public string Hora { get; set; }



    public User User {get;set;}

     public int UserId {get;set;}



   
    public List<PedidoDetalhado> PedidoDetalhados {get;set;}
   
  

    }