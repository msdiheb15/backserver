using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Data.Context
{
    public class DataContext : DbContext

    {
        
        public DataContext(DbContextOptions<DataContext>options): base (options)
        {
                
        }
     
        public DbSet<Person> Persons { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tache> Taches { get; set; }
        public DbSet<TimesSheet> TimesSheets { get; set; }
        public DbSet<ServiceDepartment> ServiceDepartments { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Person>()
                .HasKey(p => p.ID_person);


            builder.Entity<Projet>()
                .HasKey(p => p.ID_Projet);


            builder.Entity<Role>()
                .HasKey(p => p.ID_Role);


            builder.Entity<Tache>()
                .HasKey(p => p.ID_Taches);

            builder.Entity<TimesSheet>()
          .HasKey(p => p.ID_TimesSheet);

            builder.Entity<Tache>()
          .HasKey(p => p.ID_Taches);

            builder.Entity<ServiceDepartment>()
        .HasKey(p => p.ID_ServiceDepartment);


            builder.Entity<Person>()
                .HasOne(r => r.Role)
                .WithMany(p => p.Persons)
                .HasForeignKey(k => k.FK_Role)
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Person>()
               .HasOne(s => s.ServiceDepartment)
               .WithMany(p => p.persons)
               .HasForeignKey(k => k.FK_ServiceDepartment)
               .OnDelete(DeleteBehavior.NoAction);




            builder.Entity<TimesSheet>()
               .HasOne(r => r.Person)
               .WithMany(p => p.TimesSheet)
               .HasForeignKey(k => k.FK_Person)
               .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Projet>()
               .HasOne(s => s.ServiceDepartment)
               .WithMany(pr => pr.Projet)
               .HasForeignKey(k => k.FK_ServiceDepartment)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Tache>()
           .HasOne(s => s.ServiceDepartment)
           .WithMany(pr => pr.Tache)
           .HasForeignKey(k => k.FK_ServiceDepartment)
           .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<TimesSheet>()
           .HasOne(ts => ts.Projet)
           .WithMany(pr => pr.TimesSheet)
           .HasForeignKey(k => k.FK_Projet)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<TimesSheet>()
         .HasOne(t => t.Tache)
         .WithMany(ts => ts.TimesSheet)
         .HasForeignKey(k => k.FK_Tache)
         .OnDelete(DeleteBehavior.NoAction);


        }




    }
}
