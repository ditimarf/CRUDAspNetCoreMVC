using System;
using System.Collections.Generic;
using System.Linq;

namespace CRUDAspNetCoreMVC.BLL
{
    public class RespostaBLL : BaseBLL<Models.Resposta>
    {
        public RespostaBLL(DAL.CRUDContext contexto) : base(contexto)
        {

        }

        public List<ModelGrupoPergunta> RetornarModelPerguntasPorCodigoAvaliacao(int codigoAvaliacao)
        {
            return contexto.Respostas.Where(x => x.CD_Avaliacao == codigoAvaliacao)
                .Select(x => new ModelGrupoPergunta
                {
                    Pergunta = x.Pergunta,
                    IN_Conhecimento = x.IN_Conhecimento
                }).ToList();
        }

        public void EditarRespostaPorCodigoAvaliacaoEModelPergunta(int codigoAvaliacao, List<ModelGrupoPergunta> perguntas)
        {
            var respostasDaAvaliacao = RetornarLista(x => x.CD_Avaliacao == codigoAvaliacao);
            foreach (var resposta in respostasDaAvaliacao)
            {
                resposta.IN_Conhecimento = (int)perguntas.FirstOrDefault(x => x.Pergunta.CD_Pergunta == resposta.CD_Pergunta).IN_Conhecimento;
                Editar(resposta);
            }
        }

        public void RemoverRespostarPorCodigoDaAvaliacao(int cD_Avaliacao)
        {
            var respostas = RetornarLista(x => x.CD_Avaliacao == cD_Avaliacao);
            Remover(respostas);
        }
    }
}
