using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class CategoriaCreateUpdateDTO
    {
    public string Nome { get; set; }

    [Required] 
    public string Descricao { get; set; }
  
    }



   