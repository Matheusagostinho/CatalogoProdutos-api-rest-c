using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoProdutos.Models;

    public class ProdutoResponseDTO
    {
   
    public int Id { get; set; }

   
  
    public string Nome { get; set; }

    
   
    public decimal Preco  { get; set; }

    
      
    public string Descricao { get; set; }

   
    public string Url_imagem { get; set; }

    
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }

  
    public CategoriaResponseDto Categoria {get;set;}
  
    }


    public class CategoriaResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
