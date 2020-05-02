using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAspNetCoreMVC.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    CD_Candidato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CH_Nome = table.Column<string>(nullable: false),
                    CH_Email = table.Column<string>(nullable: false),
                    CH_Cidade = table.Column<string>(nullable: false),
                    CH_Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.CD_Candidato);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
