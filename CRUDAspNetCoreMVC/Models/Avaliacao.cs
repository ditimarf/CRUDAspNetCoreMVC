using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAspNetCoreMVC.Models
{
    public class Avaliacao
    {
        [Key]
        [Display(Name = "Código Avaliação")]
        public int CD_Avaliacao { get; set; }

        [Display(Name = "Disponível até 4 horas por dia")]
        public bool VF_DisponivelAte4HorasPorDia { get; set; }
        [Display(Name = "Disponível de 4 até 6 horas por dia")]
        public bool VF_DisponivelDe4A6HorasPorDia { get; set; }
        [Display(Name = "Disponível de 6 até 8 horas por dia")]
        public bool VF_DisponivelDe6A8HorasPorDia { get; set; }
        [Display(Name = "Disponível acima de 8 horas por dia")]
        public bool VF_DisponivelAcimaDe8HorasPorDia { get; set; }
        [Display(Name = "Disponível apenas nos finais de semana")]
        public bool VF_DisponivelApenasFinaisDeSemana{ get; set; }

        [Display(Name = "Manhã (de 08:00 ás 12:00)")]
        public bool VF_TrabalharDeManha { get; set; }
        [Display(Name = "Tarde (de 13:00 ás 18:00)")]
        public bool VF_TrabalharATarde { get; set; }
        [Display(Name = "Noite (de 19:00 as 22:00)")]
        public bool VF_TrabalharANoite{ get; set; }
        [Display(Name = "Madrugada (de 22:00 em diante)")]
        public bool VF_TrabalharDeMadrugada{ get; set; }
        [Display(Name = "Horário comercial (de 08:00 as 18:00)")]
        public bool VF_TrabalharHorarioComercial{ get; set; }

        [Required(ErrorMessage ="Informe sua pretenção salarial")]
        [Display(Name = "Pretenção salarial por hora")]
        public decimal? VR_PretencaoSalarioPorHora { get; set; }

        [Display(Name ="Conhecimentos extras")]
        public string CH_ConhecimentosNaoListados { get; set; }

        [Display(Name ="Data da avaliação")]
        public DateTime DT_Avaliacao { get; set; }

        [Display(Name = "Código do candidato")]
        public int CD_Candidato { get; set; }

        [ForeignKey("CD_Candidato")]
        public virtual Candidato Candidato { get; set; }

        //public virtual List<Resposta> Respostas { get; set; }

        //#region Conhecimentos
        //public int IN_ConhecimentoEmIonic { get; set; }
        //public int IN_ConhecimentoEmReactJS{ get; set; }
        //public int IN_ConhecimentoEmReactNative{ get; set; }
        //public int IN_ConhecimentoEmAndroid{ get; set; }
        //public int IN_ConhecimentoEmFlutter { get; set; }
        //public int IN_ConhecimentoEmSwift { get; set; }
        //public int IN_ConhecimentoEmIOS { get; set; }
        //public int IN_ConhecimentoEmHTML { get; set; }
        //public int IN_ConhecimentoEmCSS { get; set; }
        //public int IN_ConhecimentoEmBootStrap { get; set; }
        //public int IN_ConhecimentoEmJquery { get; set; }
        //public int IN_ConhecimentoEmAngularJS1 { get; set; }
        //public int IN_ConhecimentoEmAngular { get; set; }
        //public int IN_ConhecimentoEmJava { get; set; }
        //public int IN_ConhecimentoEmPython { get; set; }
        //public int IN_ConhecimentoEmFlask { get; set; }
        //public int IN_ConhecimentoEmAspNetMVC { get; set; }
        //public int IN_ConhecimentoEmAspNetWebForm { get; set; }
        //public int IN_ConhecimentoEmC { get; set; }
        //public int IN_ConhecimentoEmCSharp { get; set; }
        //public int IN_ConhecimentoEmNodeJs { get; set; }
        //public int IN_ConhecimentoEmExpressNodeJs { get; set; }
        //public int IN_ConhecimentoEmCake { get; set; }
        //public int IN_ConhecimentoEmDjango { get; set; }
        //public int IN_ConhecimentoEmMajento { get; set; }
        //public int IN_ConhecimentoEmPHP { get; set; }
        //public int IN_ConhecimentoEmVue { get; set; }
        //public int IN_ConhecimentoEmWordPress { get; set; }
        //public int IN_ConhecimentoEmRuby { get; set; }
        //public int IN_ConhecimentoEmMySqlServer { get; set; }
        //public int IN_ConhecimentoEmSalesForce { get; set; }
        //public int IN_ConhecimentoEmPhotoShop { get; set; }
        //public int IN_ConhecimentoEmIllustrator { get; set; }
        //public int IN_ConhecimentoEmSEO { get; set; }
        //public int IN_ConhecimentoEmLaravel { get; set; }
        //#endregion

    }
}
