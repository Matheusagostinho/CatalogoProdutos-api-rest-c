using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class Categoria
    {
    [Required]
    public int Id { get; set; }

    [Required]
     [Column(TypeName ="varchar(255)")]
    public string Nome { get; set; }

    [Required]
     [Column(TypeName ="text")]
    public string Descricao { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }





    

    //Propriedade de navegacao
    public List<Produto> Produtos {get;set;}

  

    }