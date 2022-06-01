using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Models;
namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        //* Criando a conexão com o banco de dados
        protected readonly IConfiguration Configuration;
        public BancoContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("DataBase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

        //* Informando a tabela
        public DbSet<ContatoModel> Contatos{get;set;}
    }
}