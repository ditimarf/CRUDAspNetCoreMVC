using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUDAspNetCoreMVC.Controllers
{
    public class CandidatoController : Controller
    {
        private DAL.CRUDContext context;
        public CandidatoController(DAL.CRUDContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var candidatos = this.context.Candidatos.ToList();
            return View(candidatos);
        }

        #region Novo
        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Models.Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return View(candidato);
            }

            new BLL.CandidatoBLL(this.context).Inserir(candidato);

            return RedirectToAction("Visualizar", new { id = candidato.CD_Candidato });
        }
        #endregion

        #region Editar
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var candidato = new BLL.CandidatoBLL(this.context).Retornar(id);
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
            candidato = new BLL.CandidatoBLL(this.context).Editar(candidato);

            return RedirectToAction("Visualizar", new { id = candidato.CD_Candidato });
        }
        #endregion

        public IActionResult Visualizar(int id)
        {
            var candidato = new BLL.CandidatoBLL(context).Retornar(id);
            return View(candidato);
        }

        #region Remover
        [HttpGet]
        public IActionResult Remover(int id)
        {
            var candidato = new BLL.CandidatoBLL(this.context).Retornar(id);
            return View(candidato);
        }

        [HttpPost]
        public IActionResult Remover(int id, Models.Candidato candidato)
        {
            candidato.CD_Candidato = id;
            new BLL.CandidatoBLL(this.context).Remover(candidato);

            return RedirectToAction("Index");
        }
        #endregion
    }
}