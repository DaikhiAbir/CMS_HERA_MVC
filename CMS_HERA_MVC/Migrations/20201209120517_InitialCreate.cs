using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS_HERA_MVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Taxe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom_Taxe = table.Column<string>(maxLength: 45, nullable: true),
                    Valeur_Taxe = table.Column<float>(nullable: false),
                    Status_Taxe = table.Column<int>(nullable: false),
                    Taxe_Col = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxe", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxe");
        }
    }
}
