﻿// <auto-generated />
using System;
using Logotech.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Logotech.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190502131027_initialisationAppLogo")]
    partial class initialisationAppLogo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity("Logotech.API.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BoitePostal");

                    b.Property<int>("CodePostal");

                    b.Property<int>("NumeroRue");

                    b.Property<int>("PatientId");

                    b.Property<string>("Pays")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Logotech.API.Models.Docteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Fonction")
                        .HasMaxLength(55);

                    b.Property<int?>("Gsm");

                    b.Property<int>("Inami");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<string>("Specialisation")
                        .HasMaxLength(55);

                    b.Property<int?>("TelFixe");

                    b.HasKey("Id");

                    b.ToTable("Docteurs");
                });

            modelBuilder.Entity("Logotech.API.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anamnese");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("DateNaissance");

                    b.Property<string>("Email");

                    b.Property<int?>("Gsm");

                    b.Property<string>("Lateralite");

                    b.Property<string>("Nom");

                    b.Property<string>("PersonneContact");

                    b.Property<string>("Prenom");

                    b.Property<int?>("TelContact");

                    b.Property<int?>("TelFixe");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Logotech.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<bool>("IsMain");

                    b.Property<int>("PatientId");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Logotech.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Deplacement")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int?>("Gsm");

                    b.Property<int>("Inami");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.Property<int?>("TelFixe");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Logotech.API.Models.Adresse", b =>
                {
                    b.HasOne("Logotech.API.Models.Patient", "Patient")
                        .WithOne("Adresse")
                        .HasForeignKey("Logotech.API.Models.Adresse", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Logotech.API.Models.Photo", b =>
                {
                    b.HasOne("Logotech.API.Models.Patient", "Patient")
                        .WithMany("Photos")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
