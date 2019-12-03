using Microsoft.EntityFrameworkCore;

namespace DRYBOX.Models
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    { }

    public DbSet<Estoque> Estoques { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<Material> Materiais { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
  }
}
