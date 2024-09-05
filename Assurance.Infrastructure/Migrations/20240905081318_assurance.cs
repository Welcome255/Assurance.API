using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assurance.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class assurance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assurance",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    ClientID = table.Column<string>(type: "TEXT", nullable: false),
                    NomClient = table.Column<string>(type: "TEXT", nullable: false),
                    PrenomClient = table.Column<string>(type: "TEXT", nullable: false),
                    DateDeNaissance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CodePartenaire = table.Column<string>(type: "TEXT", nullable: false),
                    CodeRabais = table.Column<int>(type: "INTEGER", nullable: false),
                    Solde = table.Column<double>(type: "REAL", nullable: false),
                    Sexe = table.Column<int>(type: "INTEGER", nullable: false),
                    EstFumeur = table.Column<bool>(type: "INTEGER", nullable: false),
                    EstDiabetique = table.Column<bool>(type: "INTEGER", nullable: false),
                    EstHypertendu = table.Column<bool>(type: "INTEGER", nullable: false),
                    PratiqueActivitePhysique = table.Column<bool>(type: "INTEGER", nullable: false),
                    Statut = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assurance", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assurance");
        }
    }
}
