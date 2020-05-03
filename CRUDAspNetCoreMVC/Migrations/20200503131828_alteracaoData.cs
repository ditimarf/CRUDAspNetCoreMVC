using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAspNetCoreMVC.Migrations
{
    public partial class alteracaoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DT_Avaliacao",
                table: "Avaliacoes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DT_Avaliacao",
                table: "Avaliacoes");
        }
    }
}
