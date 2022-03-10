using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HR");

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "HR",
                columns: table => new
                {
                    ID_Role = table.Column<Guid>(nullable: false),
                    Libelle_Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID_Role);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDepartments",
                schema: "HR",
                columns: table => new
                {
                    ID_ServiceDepartment = table.Column<Guid>(nullable: false),
                    libelle_service = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDepartments", x => x.ID_ServiceDepartment);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "HR",
                columns: table => new
                {
                    ID_person = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Cin = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Activation = table.Column<bool>(nullable: false),
                    FK_ServiceDepartment = table.Column<Guid>(nullable: false),
                    FK_Role = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.ID_person);
                    table.ForeignKey(
                        name: "FK_Persons_Roles_FK_Role",
                        column: x => x.FK_Role,
                        principalSchema: "HR",
                        principalTable: "Roles",
                        principalColumn: "ID_Role");
                    table.ForeignKey(
                        name: "FK_Persons_ServiceDepartments_FK_ServiceDepartment",
                        column: x => x.FK_ServiceDepartment,
                        principalSchema: "HR",
                        principalTable: "ServiceDepartments",
                        principalColumn: "ID_ServiceDepartment");
                });

            migrationBuilder.CreateTable(
                name: "Projets",
                schema: "HR",
                columns: table => new
                {
                    ID_Projet = table.Column<Guid>(nullable: false),
                    Nom_Projet = table.Column<string>(nullable: true),
                    Nom_Client = table.Column<string>(nullable: true),
                    Etat_projet = table.Column<string>(nullable: true),
                    Description_projet = table.Column<string>(nullable: true),
                    Debut_estime = table.Column<string>(nullable: true),
                    Fin_estime = table.Column<string>(nullable: true),
                    Debut_estimej = table.Column<int>(nullable: false),
                    Fin_estimej = table.Column<int>(nullable: false),
                    FK_ServiceDepartment = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.ID_Projet);
                    table.ForeignKey(
                        name: "FK_Projets_ServiceDepartments_FK_ServiceDepartment",
                        column: x => x.FK_ServiceDepartment,
                        principalSchema: "HR",
                        principalTable: "ServiceDepartments",
                        principalColumn: "ID_ServiceDepartment");
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                schema: "HR",
                columns: table => new
                {
                    ID_Taches = table.Column<Guid>(nullable: false),
                    Nom_tache = table.Column<string>(nullable: true),
                    Discription = table.Column<string>(nullable: true),
                    FK_ServiceDepartment = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.ID_Taches);
                    table.ForeignKey(
                        name: "FK_Taches_ServiceDepartments_FK_ServiceDepartment",
                        column: x => x.FK_ServiceDepartment,
                        principalSchema: "HR",
                        principalTable: "ServiceDepartments",
                        principalColumn: "ID_ServiceDepartment");
                });

            migrationBuilder.CreateTable(
                name: "TimesSheets",
                schema: "HR",
                columns: table => new
                {
                    ID_TimesSheet = table.Column<Guid>(nullable: false),
                    Heure_debut = table.Column<string>(nullable: true),
                    Heure_fin = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Validation = table.Column<bool>(nullable: false),
                    CreatedNow = table.Column<string>(nullable: true),
                    FK_Person = table.Column<Guid>(nullable: false),
                    FK_Projet = table.Column<Guid>(nullable: false),
                    FK_Tache = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimesSheets", x => x.ID_TimesSheet);
                    table.ForeignKey(
                        name: "FK_TimesSheets_Persons_FK_Person",
                        column: x => x.FK_Person,
                        principalSchema: "HR",
                        principalTable: "Persons",
                        principalColumn: "ID_person");
                    table.ForeignKey(
                        name: "FK_TimesSheets_Projets_FK_Projet",
                        column: x => x.FK_Projet,
                        principalSchema: "HR",
                        principalTable: "Projets",
                        principalColumn: "ID_Projet");
                    table.ForeignKey(
                        name: "FK_TimesSheets_Taches_FK_Tache",
                        column: x => x.FK_Tache,
                        principalSchema: "HR",
                        principalTable: "Taches",
                        principalColumn: "ID_Taches");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FK_Role",
                schema: "HR",
                table: "Persons",
                column: "FK_Role");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_FK_ServiceDepartment",
                schema: "HR",
                table: "Persons",
                column: "FK_ServiceDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_Projets_FK_ServiceDepartment",
                schema: "HR",
                table: "Projets",
                column: "FK_ServiceDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_FK_ServiceDepartment",
                schema: "HR",
                table: "Taches",
                column: "FK_ServiceDepartment");

            migrationBuilder.CreateIndex(
                name: "IX_TimesSheets_FK_Person",
                schema: "HR",
                table: "TimesSheets",
                column: "FK_Person");

            migrationBuilder.CreateIndex(
                name: "IX_TimesSheets_FK_Projet",
                schema: "HR",
                table: "TimesSheets",
                column: "FK_Projet");

            migrationBuilder.CreateIndex(
                name: "IX_TimesSheets_FK_Tache",
                schema: "HR",
                table: "TimesSheets",
                column: "FK_Tache");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimesSheets",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Projets",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Taches",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "HR");

            migrationBuilder.DropTable(
                name: "ServiceDepartments",
                schema: "HR");
        }
    }
}
