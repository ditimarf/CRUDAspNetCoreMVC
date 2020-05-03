using CRUDAspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CRUDAspNetCoreMVC.Controllers
{
    public class AvaliacaoController : Controller
    {
        private DAL.CRUDContext contexto;
        public AvaliacaoController(DAL.CRUDContext contexto)
        {
            this.contexto = contexto;
        }

        //id=CodigoCandidato
        public ActionResult NovaAvaliacao(int id)
        {
            var model = new ModelNovaAvaliacao
            {
                Avaliacao = new Avaliacao() { CD_Candidato = id },
                //CD_Candidato = id,
                listaGrupoPergunta = new List<ModelGrupoPergunta>()};

            var listaPerguntas = new BLL.PerguntaBLL(contexto).RetornarLista();
            foreach (var pergunta in listaPerguntas)
                model.listaGrupoPergunta.Add(new ModelGrupoPergunta{ Pergunta = pergunta, IN_Conhecimento = null});
            
            return View("Avaliacao", model);
        }

        [HttpPost]
        public IActionResult Salvar(ModelNovaAvaliacao model)
        {
            if (!ModelState.IsValid)
            {
                return View("Avaliacao", model);
            }

            model.Avaliacao.DT_Avaliacao = DateTime.Now;
            var avaliacao = new BLL.AvaliacaoBLL(contexto).Inserir(model.Avaliacao);
            var listaDeResposta = model.listaGrupoPergunta.Select(x =>
                new Resposta
                {
                    CD_Avaliacao = avaliacao.CD_Avaliacao,
                    CD_Pergunta = x.Pergunta.CD_Pergunta,
                    IN_Conhecimento = (int)x.IN_Conhecimento
                }).ToList();
            new BLL.RespostaBLL(contexto).Inserir(listaDeResposta);

            return RedirectToAction("Visualizar", "Candidato", new { id = avaliacao.CD_Candidato});
        }
    }
}

public class ModelNovaAvaliacao
{
    public Avaliacao Avaliacao { get; set; }
    //public int CD_Candidato { get; set; }
    public List<ModelGrupoPergunta> listaGrupoPergunta { get; set; }
}

public class ModelGrupoPergunta
{
    public Pergunta Pergunta { get; set; }
    [Required(ErrorMessage ="Selecione uma opção")]
    public int? IN_Conhecimento { get; set; }
}