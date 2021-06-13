using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_Rosmery.Models;

namespace T3_Rosmery.DB
{
    public class EjercicioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<RutinaUsuario> RutinaUsuarios { get; set; }
        public DbSet<DetalleRutina> DetalleRutinas { get; set; }

        public EjercicioContext(DbContextOptions<EjercicioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EjerciciosMap());
            modelBuilder.ApplyConfiguration(new RutinaUsuarioMap());
            modelBuilder.ApplyConfiguration(new DetalleRutinaMap());

        }
    }
}
