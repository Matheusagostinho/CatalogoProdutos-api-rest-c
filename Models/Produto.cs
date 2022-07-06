using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class Produto
    {
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName ="varchar(255)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "decimal(12,2)")]
    public decimal Preco  { get; set; }

    [Required]  
      [Column(TypeName ="text")]
    public string Descricao { get; set; }

    [Required]
      [Column(TypeName ="text")]
    public string Url_imagem { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }





    

    //Propriedade de navegacao
    public List<PedidoDetalhado> PedidoDetalhados {get;set;}


    //Chave estrangeira
    public Categoria Categoria {get;set;}
   
    public int? CategoriaId  {get;set;}

  

    }