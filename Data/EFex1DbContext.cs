using EFex1.Models;
using Microsoft.EntityFrameworkCore;

namespace EFex1.Data
    {
        public class RFex1DbContext : DbContext
        {
            public DbSet<Categoria>  Categorias {get; set;}
            public DbSet<Produto>  Produtos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EFex1DataAnnotation;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;");
        
        }
    }

    
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //=> options.UseSqlServer("Server=localhost,1433;Database=EFex1DataAnnotation;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;");