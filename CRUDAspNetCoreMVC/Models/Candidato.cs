using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "O campo Telefone é obrigatorio")]
        [Display(Name = "Telefone")]
        [DataTypeAttribute(DataType.PhoneNumber)]
        public string CH_Telefone { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatorio")]
        [Display(Name = "Email")]
        [DataTypeAttribute(DataType.EmailAddress)]
        public string CH_Email { get; set; }

        [Required(ErrorMessage = "O campo CIDADE é obrigatorio")]
        [Display(Name = "Cidade")]
        public string CH_Cidade { get; set; }

        [Required(ErrorMessage = "O campo ESTADO é obrigatorio")]
        [Display(Name = "Estado")]
        public string CH_Estado { get; set; }

        //public virtual List<Avaliacao> Avaliacoes{ get; set; }
    }
}
