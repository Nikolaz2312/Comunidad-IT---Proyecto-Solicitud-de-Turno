using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TurnoProyecto.Models
{
    public class TurnoContext : DbContext
    {
        public TurnoContext(DbContextOptions<TurnoContext> options)
        : base(options)
        { }

        public DbSet<TurnoModelDatos> TurnoDb {get;set;}

        public DbSet<UserModelDatos> UserDb {get;set;}
         public DbSet<User2ModelDatos> UserSDb {get;set;}
      
        public DbSet<NumeroDeTurnoModelDatos> NTurnoDb{get;set;}
       
        public DbSet<AsignarTurno> AsignarDB {get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("turnodb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}