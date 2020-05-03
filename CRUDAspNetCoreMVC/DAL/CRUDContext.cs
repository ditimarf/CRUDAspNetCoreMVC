using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CRUDAspNetCoreMVC.DAL
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
            //Database.Migrate();
            Database.EnsureCreated();
        }

        public DbSet<Models.Candidato> Candidatos { get; set; }
        public DbSet<Models.Avaliacao> Avaliacoes { get; set; }
        public DbSet<Models.Pergunta> Perguntas { get; set; }
        public DbSet<Models.Resposta> Respostas { get; set; }

        public static CRUDContext RetornarContextoDeConexao()
        {
            using (var serviceScope = Startup.app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                return serviceScope.ServiceProvider.GetRequiredService<DAL.CRUDContext>();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var i = 1;

            modelBuilder.Entity<Models.Candidato>().HasData(
                new Models.Candidato
                {
                    CD_Candidato = 1,
                    CH_Nome = "Ditimar Moita Cardozo Filho",
                    CH_Telefone = "(88)9.9401-1545",
                    CH_Email = "ditimarf@gmail.com",
                    CH_Cidade = "Tianguá",
                    CH_Estado = "Ceará"
                });

            var perguntas = new List<Models.Pergunta>
            {
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "IONIC" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "ReactJS" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "ReactNative" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Android" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Flutter" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Swift" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "IOS" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "HTML" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "CSS" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "BootStrap" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "JQuery" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Angular JS 1" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Angular" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Java" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Python" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Flask" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Asp.Net MVC" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Asp.Net WebForm" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "C" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "C#" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "NodeJS" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Express - NodeJS" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Cake" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Django" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Majento" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "PHP" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Vue" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "WordPress" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Ruby" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "My Sql Server" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "SalesForce" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Illustrator" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "SEO" },
                new Models.Pergunta { CD_Pergunta = i++, CH_Descricao = "Laravel" }
            };
            modelBuilder.Entity<Models.Pergunta>().HasData(perguntas.ToArray());

            modelBuilder.Entity<Models.Avaliacao>().HasData(
               new Models.Avaliacao
               {
                   CD_Avaliacao = 1,
                   CD_Candidato = 1,
                   DT_Avaliacao = DateTime.Now,
                   VF_DisponivelAcimaDe8HorasPorDia = true,
                   VF_DisponivelApenasFinaisDeSemana = true,
                   VF_DisponivelAte4HorasPorDia = false,
                   VF_DisponivelDe4A6HorasPorDia = true,
                   VF_DisponivelDe6A8HorasPorDia = true,
                   VF_TrabalharANoite = true,
                   VF_TrabalharATarde = true,
                   VF_TrabalharDeMadrugada = true,
                   VF_TrabalharDeManha = true,
                   VF_TrabalharHorarioComercial = true,
                   VR_PretencaoSalarioPorHora = 20,
                   CH_ConhecimentosNaoListados = ""
               });

            var respostas = new List<Models.Resposta>();

            i = 1;
            foreach (var p in perguntas)
                respostas.Add(new Models.Resposta
                {
                    CD_Resposta = i++,
                    CD_Avaliacao = 1,
                    CD_Pergunta = p.CD_Pergunta,
                    IN_Conhecimento = new Random().Next(5)
                });

            modelBuilder.Entity<Models.Resposta>().HasData(respostas.ToArray());
        }
    }
}
