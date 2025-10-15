using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minimal.Dominios.entidades;

namespace Minimal.Infraestrutura.Db
{
    
    public class DBContext : DbContext
    {
        private readonly IConfiguration _ConfigAppSets;
        public DBContext(IConfiguration ConfigAppSets)
        {
            _ConfigAppSets = ConfigAppSets;
        }
        
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Veiculo> Veiculos{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador{
                    Id=1,
                    Email="adm@gmail.com",
                    Senha="123456",
                    Perfil="Adm"

                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringdeconecao = _ConfigAppSets.GetConnectionString("mysql")?.ToString();
            optionsBuilder.UseMySql(
                stringdeconecao,
            ServerVersion.AutoDetect(stringdeconecao)
            );
        }
    }
}