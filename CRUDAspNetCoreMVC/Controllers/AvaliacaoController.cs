using CRUDAspNetCoreMVC.Enums;
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

        #region Nova Avaliacao
        //id=CodigoCandidato
        [Route("Avaliacao/Nova/{id}")]
        public ActionResult NovaAvaliacao(int id)
        {
            var model = new ModelAvaliacao
            {
                Operacao = EnumCRUD.CREATE,
                Avaliacao = new Avaliacao() { CD_Candidato = id },
                listaGrupoPergunta = new List<ModelGrupoPergunta>()
            };

            var listaPerguntas = new BLL.PerguntaBLL(contexto).RetornarLista();
            foreach (var pergunta in listaPerguntas)
                model.listaGrupoPergunta.Add(new ModelGrupoPergunta { Pergunta = pergunta, IN_Conhecimento = null });

            return View("Avaliacao", model);
        }

        [HttpPost]
        [Route("Avaliacao/Salvar")]
        public IActionResult Salvar(ModelAvaliacao model)
        {
            if (!ModelState.IsValid)
            {
                if (this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Count == 1
                 && this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors[0].ErrorMessage.Contains("is not valid for"))
                {
                    this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Clear();
                    this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Add("Valor inválido para pretenção salarial");
                }

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

            return RedirectToAction("Visualizar", "Candidato", new { id = avaliacao.CD_Candidato });
        }
        #endregion

        #region Visualizacao
        //id = codigoAvaliacao
        [Route("Avaliacao/{id}")]
        public IActionResult Visualizar(int id)
        {
            var modelAvaliacao = new ModelAvaliacao
            {
                Operacao = EnumCRUD.READ,
                Avaliacao = new BLL.AvaliacaoBLL(this.contexto).Retornar(id),
                listaGrupoPergunta = new BLL.RespostaBLL(this.contexto).RetornarModelPerguntasPorCodigoAvaliacao(id)
            };

            return View("Avaliacao", modelAvaliacao);
        }
        #endregion

        #region Editar Avaliacao
        //id = codigoAvaliacao
        [Route("Avaliacao/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var modelAvaliacao = new ModelAvaliacao
            {
                Operacao = EnumCRUD.UPDATE,
                Avaliacao = new BLL.AvaliacaoBLL(this.contexto).Retornar(id),
                listaGrupoPergunta = new BLL.RespostaBLL(this.contexto).RetornarModelPerguntasPorCodigoAvaliacao(id)
            };

            return View("Avaliacao", modelAvaliacao);
        }

        [HttpPost]
        [Route("Avaliacao/Editar/{id}")]
        public IActionResult Editar(ModelAvaliacao model)
        {
            if (!ModelState.IsValid)
            {
                if (this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Count == 1
                 && this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors[0].ErrorMessage.Contains("is not valid for"))
                {
                    this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Clear();
                    this.ModelState["Avaliacao.VR_PretencaoSalarioPorHora"].Errors.Add("Valor inválido para pretenção salarial");
                }

                return View("Avaliacao", model);
            }

            var avaliacao = new BLL.AvaliacaoBLL(contexto).Editar(model.Avaliacao);
            new BLL.RespostaBLL(contexto).EditarRespostaPorCodigoAvaliacaoEModelPergunta(avaliacao.CD_Avaliacao, model.listaGrupoPergunta);

            return RedirectToAction("Visualizar", "Candidato", new { id = avaliacao.CD_Candidato });
        }
        #endregion

        #region Remover Avaliacao
        //id = codigoAvaliacao
        [Route("Avaliacao/Remover/{id}")]
        public IActionResult Remover(int id)
        {
            var modelAvaliacao = new ModelAvaliacao
            {
                Operacao = EnumCRUD.DELETE,
                Avaliacao = new BLL.AvaliacaoBLL(this.contexto).Retornar(id),
                listaGrupoPergunta = new BLL.RespostaBLL(this.contexto).RetornarModelPerguntasPorCodigoAvaliacao(id)
            };

            return View("Avaliacao", modelAvaliacao);
        }

        [HttpPost]
        [Route("Avaliacao/Remover/{id}")]
        public IActionResult Remover(ModelAvaliacao model)
        {
            new BLL.RespostaBLL(contexto).RemoverRespostarPorCodigoDaAvaliacao(model.Avaliacao.CD_Avaliacao);
            new BLL.AvaliacaoBLL(contexto).Remover(model.Avaliacao);

            return RedirectToAction("Visualizar", "Candidato", new { id = model.Avaliacao.CD_Candidato });
        }
        #endregion
    }
}

public class ModelAvaliacao
{
    public EnumCRUD Operacao { get; set; }
    public Avaliacao Avaliacao { get; set; }
    public List<ModelGrupoPergunta> listaGrupoPergunta { get; set; }
}

public class ModelGrupoPergunta
{
    public Pergunta Pergunta { get; set; }
    [Required(ErrorMessage = "Selecione uma opção")]
    public int? IN_Conhecimento { get; set; }
}