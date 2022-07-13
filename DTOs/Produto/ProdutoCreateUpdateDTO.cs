using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class ProdutoCreateUpdateDTO
    {

    [Required]
    [StringLength(255, MinimumLength = 3)]
    public string Nome { get; set; }

    [Required]
    [Range(0, 1_000_000)]
    public decimal Preco  { get; set; }

    [Required] 
    public string Descricao { get; set; }

    [Required]
    public string Url_imagem { get; set; }
    public int CategoriaId { get; set; }


  
    }



   