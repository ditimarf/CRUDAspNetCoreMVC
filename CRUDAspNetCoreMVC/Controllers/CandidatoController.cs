using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUDAspNetCoreMVC.Controllers
{
    public class CandidatoController : Controller
    {
        private DAL.CRUDContext contexto;
        public CandidatoController(DAL.CRUDContext context)
        {
            this.contexto = context;
        }

        #region Listagem
        public IActionResult Index()
        {
            var candidatos = this.contexto.Candidatos.ToList();
            return View(candidatos);
        }

        [Route("Candidatos/{filtro}")]
        public IActionResult Index(string filtro)
        {
            var candidatos = this.contexto.Candidatos.Where(x => x.CH_Nome.Contains(filtro)).ToList();
            return View(candidatos);
        }
        #endregion

        #region Novo
        [HttpGet]
        [Route("Candidato/Novo")]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [Route("Candidato/Novo")]
        public IActionResult Novo(Models.Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return View(candidato);
            }

            new BLL.CandidatoBLL(this.contexto).Inserir(candidato);

            return RedirectToAction("Visualizar", new { id = candidato.CD_Candidato });
        }
        #endregion

        #region Editar
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var candidato = new BLL.CandidatoBLL(this.contexto).Retornar(id);
            return View(candidato);
        }

        [HttpPost]
        public IActionResult Editar(int id, Models.Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return View(candidato);
            }

            candidato.CD_Candidato = id;
            candidato = new BLL.CandidatoBLL(this.contexto).Editar(candidato);

            return RedirectToAction("Visualizar", new { id = candidato.CD_Candidato });
        }
        #endregion

        #region Visualizar
        [Route("Candidato/{id}")]
        public IActionResult Visualizar(int id)
        {
            var model = new ModelVisualizacaoCandidato();
            model.Candidato = new BLL.CandidatoBLL(contexto).Retornar(id);
            model.Avaliacoes = new BLL.AvaliacaoBLL(contexto).RetornarAvaliacoesPorCodigoCandidato(id);
            return View(model);
        } 
        #endregion

        #region Remover
        [HttpGet]
        public IActionResult Remover(int id)
        {
            var candidato = new BLL.CandidatoBLL(this.contexto).Retornar(id);
            return View(candidato);
        }

        [HttpPost]
        public IActionResult Remover(int id, Models.Candidato candidato)
        {
            candidato.CD_Candidato = id;

            new BLL.AvaliacaoBLL(this.contexto).RetornarAvaliacoesPorCodigoCandidato(id);
            new BLL.CandidatoBLL(this.contexto).Remover(candidato);

            return RedirectToAction("Index");
        }
        #endregion
    }
}

public class ModelVisualizacaoCandidato
{
    public CRUDAspNetCoreMVC.Models.Candidato Candidato { get; set; }
    public List<CRUDAspNetCoreMVC.Models.Avaliacao> Avaliacoes{ get; set; }
}