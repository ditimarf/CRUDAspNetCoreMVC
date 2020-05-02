using System.ComponentModel.DataAnnotations;

namespace CRUDAspNetCoreMVC.Models
{
    public class Pergunta
    {   
        [Key]
        [Display(Name = "Código da pergunta")]
        public int CD_Pergunta { get; set; }

        [Display(Name = "Descrição da pergunta")]
        public string CH_Descricao { get; set; }
    }
}
