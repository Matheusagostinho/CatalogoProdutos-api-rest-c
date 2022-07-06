using Microsoft.EntityFrameworkCore;
using CatalogoProdutos.Models;
namespace CatalogoProdutos.Data;

public class CatalogoProdutosContext : DbContext
{
    public CatalogoProdutosContext(DbContextOptions<CatalogoProdutosContext> options) : base(options)
    {       
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<PedidoDetalhado> PedidoDetalhado { get; set; }
}
