using Microsoft.EntityFrameworkCore;
using Teste_FCS.Models;

namespace Teste_FCS.Context
{
    public class Db_Context : DbContext
    {
        public Db_Context(DbContextOptions<Db_Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Coloque um servidor padrão
                optionsBuilder.UseSqlServer("Server=MEUSERVIDOR;Database=MeuBancoDeDados;Trusted_Connection=True;");
            }
        }

        // Adicione o DbSet para mapear o UserModel
         public DbSet<LivroModel> Livros { get; set; }

    }
}
