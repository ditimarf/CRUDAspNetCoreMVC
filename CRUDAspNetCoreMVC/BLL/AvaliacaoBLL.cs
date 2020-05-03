using System.Collections.Generic;

namespace CRUDAspNetCoreMVC.BLL
{
    public class AvaliacaoBLL : BaseBLL<Models.Avaliacao>
    {
        public AvaliacaoBLL(DAL.CRUDContext contexto) : base(contexto)
        {
        }

        public List<Models.Avaliacao> RetornarAvaliacoesPorCodigoCandidato(int codigoCandidato)
        {
            return RetornarLista(x => x.CD_Candidato == codigoCandidato);
        }
    }
}
