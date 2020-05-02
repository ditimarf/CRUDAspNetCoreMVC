using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUDAspNetCoreMVC.Migrations
{
    public partial class PrimeiraMigracao : Migration
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
                    CH_Telefone = table.Column<string>(nullable: false),
                    CH_Email = table.Column<string>(nullable: false),
                    CH_Cidade = table.Column<string>(nullable: false),
                    CH_Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.CD_Candidato);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    CD_Pergunta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CH_Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.CD_Pergunta);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    CD_Avaliacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VF_DisponivelAte4HorasPorDia = table.Column<bool>(nullable: false),
                    VF_DisponivelDe4A6HorasPorDia = table.Column<bool>(nullable: false),
                    VF_DisponivelDe6A8HorasPorDia = table.Column<bool>(nullable: false),
                    VF_DisponivelAcimaDe8HorasPorDia = table.Column<bool>(nullable: false),
                    VF_DisponivelApenasFinaisDeSemana = table.Column<bool>(nullable: false),
                    VF_TrabalharDeManha = table.Column<bool>(nullable: false),
                    VF_TrabalharATarde = table.Column<bool>(nullable: false),
                    VF_TrabalharANoite = table.Column<bool>(nullable: false),
                    VF_TrabalharDeMadrugada = table.Column<bool>(nullable: false),
                    VF_TrabalharHorarioComercial = table.Column<bool>(nullable: false),
                    VR_PretencaoSalarioPorHora = table.Column<decimal>(nullable: false),
                    CD_Candidato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.CD_Avaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Candidatos_CD_Candidato",
                        column: x => x.CD_Candidato,
                        principalTable: "Candidatos",
                        principalColumn: "CD_Candidato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    CD_Resposta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CD_Avaliacao = table.Column<int>(nullable: false),
                    CD_Pergunta = table.Column<int>(nullable: false),
                    IN_Conhecimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.CD_Resposta);
                    table.ForeignKey(
                        name: "FK_Respostas_Avaliacoes_CD_Avaliacao",
                        column: x => x.CD_Avaliacao,
                        principalTable: "Avaliacoes",
                        principalColumn: "CD_Avaliacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_CD_Pergunta",
                        column: x => x.CD_Pergunta,
                        principalTable: "Perguntas",
                        principalColumn: "CD_Pergunta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_CD_Candidato",
                table: "Avaliacoes",
                column: "CD_Candidato");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_CD_Avaliacao",
                table: "Respostas",
                column: "CD_Avaliacao");

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_CD_Pergunta",
                table: "Respostas",
                column: "CD_Pergunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Candidatos");
        }
    }
}
