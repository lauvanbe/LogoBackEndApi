﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Logotech.API.Migrations
{
    public partial class initialisationAppLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Inami = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(maxLength: 55, nullable: false),
                    Prenom = table.Column<string>(maxLength: 55, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    TelFixe = table.Column<int>(nullable: true),
                    Gsm = table.Column<int>(nullable: true),
                    Specialisation = table.Column<string>(maxLength: 55, nullable: true),
                    Fonction = table.Column<string>(maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    TelFixe = table.Column<int>(nullable: true),
                    Gsm = table.Column<int>(nullable: true),
                    PersonneContact = table.Column<string>(nullable: true),
                    TelContact = table.Column<int>(nullable: true),
                    Anamnese = table.Column<string>(nullable: true),
                    Lateralite = table.Column<string>(nullable: true),
                    Commentaire = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Inami = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(maxLength: 55, nullable: false),
                    Prenom = table.Column<string>(maxLength: 55, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    TelFixe = table.Column<int>(nullable: true),
                    Gsm = table.Column<int>(nullable: true),
                    Deplacement = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rue = table.Column<string>(maxLength: 55, nullable: false),
                    NumeroRue = table.Column<int>(nullable: false),
                    BoitePostal = table.Column<int>(nullable: true),
                    CodePostal = table.Column<int>(nullable: false),
                    Ville = table.Column<string>(maxLength: 55, nullable: false),
                    Pays = table.Column<string>(maxLength: 55, nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false),
                    PublicId = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PatientId",
                table: "Adresses",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PatientId",
                table: "Photos",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Docteurs");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
