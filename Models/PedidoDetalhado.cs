using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class PedidoDetalhado
    {
    [Required]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Quantidade { get; set; }






    //Propriedade de navegacao
    public int? PedidoId  {get;set;}
    public Pedido Pedido {get;set;}
  
    public int? ProdutoId  {get;set;}
    public Produto Produtos {get;set;}
   
    

    }