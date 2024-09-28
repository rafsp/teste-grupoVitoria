using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeatWise_Sprint_2.Net.Persistencia.Models
{
    [Table("Analise")]
    public class Analise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O relatório é obrigatório.")]
        public string Relatorio { get; set; }

        [Required(ErrorMessage = "O tempo de tela ativa é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public double TempoTelaAtiva { get; set; }

        [Required(ErrorMessage = "O tempo de inatividade é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public double TempoInatividade { get; set; }

        [Required(ErrorMessage = "O número de cliques do mouse é obrigatório.")]
        [Column(TypeName = "int")]
        public int NumeroCliquesMouse { get; set; }

        [Required(ErrorMessage = "O número de teclas pressionadas é obrigatório.")]
        [Column(TypeName = "int")]
        public int NumeroTeclasPressionadas { get; set; }

        [Required(ErrorMessage = "O tempo médio de conclusão de tarefas é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public double TempoMedioConclusaoTarefas { get; set; }

        [Required(ErrorMessage = "O número de tarefas concluídas por tempo é obrigatório.")]
        [Column(TypeName = "int")]
        public int TarefasConcluidasPorTempo { get; set; }

        [Required(ErrorMessage = "A taxa de erros é obrigatória.")]
        [Column(TypeName = "decimal(18,2)")]
        public double TaxaErros { get; set; }

        [Required(ErrorMessage = "O tempo médio de correção de erros é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public double TempoMedioCorrecaoErros { get; set; }

        [Required(ErrorMessage = "O índice de eficiência é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        public double IndiceEficiencia { get; set; }

        [Required(ErrorMessage = "A satisfação do usuário é obrigatória.")]
        [Column(TypeName = "decimal(18,2)")]
        public double SatisfacaoUsuario { get; set; }

        // Relacionamento com Site
        [ForeignKey("Site")]
        public long SiteId { get; set; }
        public Site Site { get; set; }
    }
}
