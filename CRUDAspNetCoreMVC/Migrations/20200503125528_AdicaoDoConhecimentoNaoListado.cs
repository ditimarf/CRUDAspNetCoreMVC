using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAspNetCoreMVC.Migrations
{
    public partial class AdicaoDoConhecimentoNaoListado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CH_ConhecimentosNaoListados",
                table: "Avaliacoes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CH_ConhecimentosNaoListados",
                table: "Avaliacoes");
        }
    }
}
