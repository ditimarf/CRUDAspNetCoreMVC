using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNetCoreMVC.Models
{
    public class Candidato
    {
        [Key]
        [Display(Name = "Id")]
        public int CD_Candidato { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatorio")]
        [Display(Name = "Nome")]
        public string CH_Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        [Display(Name = "Email")]
        public string CH_Email { get; set; }

        [Required(ErrorMessage = "O campo CIDADE é obrigatorio")]
        [Display(Name = "Cidade")]
        public string CH_Cidade { get; set; }

        [Required(ErrorMessage = "O campo ESTADO é obrigatorio")]
        [Display(Name = "Estado")]
        public string CH_Estado { get; set; }
    }
}
