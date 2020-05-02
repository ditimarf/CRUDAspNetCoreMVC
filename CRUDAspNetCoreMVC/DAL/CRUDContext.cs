using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRUDAspNetCoreMVC.DAL
{
    public class CRUDContext : DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public static CRUDContext RetornarContextoDeConexao()
        {
            using (var serviceScope = Startup.app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                return serviceScope.ServiceProvider.GetRequiredService<DAL.CRUDContext>();
            }
        }

        public DbSet<Models.Candidato> Candidatos { get; set; }
        public DbSet<Models.Avaliacao> Avaliacoes { get; set; }
        public DbSet<Models.Pergunta> Perguntas { get; set; }
        public DbSet<Models.Resposta> Respostas { get; set; }
    }
}
