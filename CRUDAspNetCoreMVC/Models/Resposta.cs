using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAspNetCoreMVC.Models
{
    public class Resposta
    {
        [Key]
        [Display(Name = "Código da resposta")]
        public int CD_Resposta { get; set; }

        [Display(Name = "Código da avaliação")]
        public int CD_Avaliacao { get; set; }

        [Display(Name ="Código da pergunta")]
        public int CD_Pergunta { get; set; }

        [Display(Name = "Nível de conhecimento")]
        public int IN_Conhecimento { get; set; }

        [ForeignKey("CD_Avaliacao")]
        public virtual Avaliacao Avaliacao { get; set; }

        [ForeignKey("CD_Pergunta")]
        public virtual Pergunta Pergunta { get; set; }
    }
}
