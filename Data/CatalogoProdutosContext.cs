using Microsoft.EntityFrameworkCore;
using CatalogoProdutos.Models;
namespace CatalogoProdutos.Data;

public class CatalogoProdutosContext : DbContext
{
    public CatalogoProdutosContext(DbContextOptions<CatalogoProdutosContext> options) : base(options)
    {       
    }

    public DbSet<User> Users { get; set; }
}
