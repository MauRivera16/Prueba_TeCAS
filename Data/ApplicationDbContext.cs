using Microsoft.EntityFrameworkCore;
using Prueba_TeCAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_TeCAS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<CuentasAhorro> Cuentasahorro { get; set; }

        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity(typeof(CuentasAhorro))
                .HasOne(typeof(Clientes), "ClientObj")
                .WithMany()
                .HasForeignKey("Cliente_id")
                .OnDelete(DeleteBehavior.Restrict);  //no ON DELETE

        }
    }
}
