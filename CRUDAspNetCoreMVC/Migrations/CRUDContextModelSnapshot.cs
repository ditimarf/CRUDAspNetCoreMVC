﻿// <auto-generated />
using System;
using CRUDAspNetCoreMVC.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDAspNetCoreMVC.Migrations
{
    [DbContext(typeof(CRUDContext))]
    partial class CRUDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Avaliacao", b =>
                {
                    b.Property<int>("CD_Avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CD_Candidato");

                    b.Property<string>("CH_ConhecimentosNaoListados");

                    b.Property<DateTime>("DT_Avaliacao");

                    b.Property<bool>("VF_DisponivelAcimaDe8HorasPorDia");

                    b.Property<bool>("VF_DisponivelApenasFinaisDeSemana");

                    b.Property<bool>("VF_DisponivelAte4HorasPorDia");

                    b.Property<bool>("VF_DisponivelDe4A6HorasPorDia");

                    b.Property<bool>("VF_DisponivelDe6A8HorasPorDia");

                    b.Property<bool>("VF_TrabalharANoite");

                    b.Property<bool>("VF_TrabalharATarde");

                    b.Property<bool>("VF_TrabalharDeMadrugada");

                    b.Property<bool>("VF_TrabalharDeManha");

                    b.Property<bool>("VF_TrabalharHorarioComercial");

                    b.Property<decimal?>("VR_PretencaoSalarioPorHora")
                        .IsRequired();

                    b.HasKey("CD_Avaliacao");

                    b.HasIndex("CD_Candidato");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Candidato", b =>
                {
                    b.Property<int>("CD_Candidato")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CH_Cidade")
                        .IsRequired();

                    b.Property<string>("CH_Email")
                        .IsRequired();

                    b.Property<string>("CH_Estado")
                        .IsRequired();

                    b.Property<string>("CH_Nome")
                        .IsRequired();

                    b.Property<string>("CH_Telefone")
                        .IsRequired();

                    b.HasKey("CD_Candidato");

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Pergunta", b =>
                {
                    b.Property<int>("CD_Pergunta")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CH_Descricao");

                    b.HasKey("CD_Pergunta");

                    b.ToTable("Perguntas");
                });

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Resposta", b =>
                {
                    b.Property<int>("CD_Resposta")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CD_Avaliacao");

                    b.Property<int>("CD_Pergunta");

                    b.Property<int>("IN_Conhecimento");

                    b.HasKey("CD_Resposta");

                    b.HasIndex("CD_Avaliacao");

                    b.HasIndex("CD_Pergunta");

                    b.ToTable("Respostas");
                });

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Avaliacao", b =>
                {
                    b.HasOne("CRUDAspNetCoreMVC.Models.Candidato", "Candidato")
                        .WithMany()
                        .HasForeignKey("CD_Candidato")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CRUDAspNetCoreMVC.Models.Resposta", b =>
                {
                    b.HasOne("CRUDAspNetCoreMVC.Models.Avaliacao", "Avaliacao")
                        .WithMany()
                        .HasForeignKey("CD_Avaliacao")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CRUDAspNetCoreMVC.Models.Pergunta", "Pergunta")
                        .WithMany()
                        .HasForeignKey("CD_Pergunta")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
