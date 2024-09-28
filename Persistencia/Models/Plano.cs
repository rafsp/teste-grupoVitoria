using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeatWise_Sprint_2.Net.Persistencia.Models
{
    [Table("Plano")]
    public class Plano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlanoId { get; set; }

        [Required(ErrorMessage = "O nome do plano é obrigatório.")]
        public string Nome { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a zero.")]
        public decimal Valor { get; set; }

        [MaxLength(255, ErrorMessage = "A descrição deve conter no máximo 255 caracteres.")]
        public string Descricao { get; set; }
    }
}
