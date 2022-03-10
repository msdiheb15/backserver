﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.Property<Guid>("ID_person")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activation")
                        .HasColumnType("bit");

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_Role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_ServiceDepartment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_person");

                    b.HasIndex("FK_Role");

                    b.HasIndex("FK_ServiceDepartment");

                    b.ToTable("Persons","HR");
                });

            modelBuilder.Entity("Domain.Models.Projet", b =>
                {
                    b.Property<Guid>("ID_Projet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Debut_estime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Debut_estimej")
                        .HasColumnType("int");

                    b.Property<string>("Description_projet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Etat_projet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_ServiceDepartment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fin_estime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fin_estimej")
                        .HasColumnType("int");

                    b.Property<string>("Nom_Client")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom_Projet")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Projet");

                    b.HasIndex("FK_ServiceDepartment");

                    b.ToTable("Projets","HR");
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<Guid>("ID_Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Libelle_Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Role");

                    b.ToTable("Roles","HR");
                });

            modelBuilder.Entity("Domain.Models.ServiceDepartment", b =>
                {
                    b.Property<Guid>("ID_ServiceDepartment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("libelle_service")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_ServiceDepartment");

                    b.ToTable("ServiceDepartments","HR");
                });

            modelBuilder.Entity("Domain.Models.Tache", b =>
                {
                    b.Property<Guid>("ID_Taches")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_ServiceDepartment")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nom_tache")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Taches");

                    b.HasIndex("FK_ServiceDepartment");

                    b.ToTable("Taches","HR");
                });

            modelBuilder.Entity("Domain.Models.TimesSheet", b =>
                {
                    b.Property<Guid>("ID_TimesSheet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedNow")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FK_Person")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Projet")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FK_Tache")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Heure_debut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heure_fin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Validation")
                        .HasColumnType("bit");

                    b.HasKey("ID_TimesSheet");

                    b.HasIndex("FK_Person");

                    b.HasIndex("FK_Projet");

                    b.HasIndex("FK_Tache");

                    b.ToTable("TimesSheets","HR");
                });

            modelBuilder.Entity("Domain.Models.Person", b =>
                {
                    b.HasOne("Domain.Models.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("FK_Role")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Models.ServiceDepartment", "ServiceDepartment")
                        .WithMany("persons")
                        .HasForeignKey("FK_ServiceDepartment")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Projet", b =>
                {
                    b.HasOne("Domain.Models.ServiceDepartment", "ServiceDepartment")
                        .WithMany("Projet")
                        .HasForeignKey("FK_ServiceDepartment")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.Tache", b =>
                {
                    b.HasOne("Domain.Models.ServiceDepartment", "ServiceDepartment")
                        .WithMany("Tache")
                        .HasForeignKey("FK_ServiceDepartment")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.TimesSheet", b =>
                {
                    b.HasOne("Domain.Models.Person", "Person")
                        .WithMany("TimesSheet")
                        .HasForeignKey("FK_Person")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Models.Projet", "Projet")
                        .WithMany("TimesSheet")
                        .HasForeignKey("FK_Projet")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Models.Tache", "Tache")
                        .WithMany("TimesSheet")
                        .HasForeignKey("FK_Tache")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
