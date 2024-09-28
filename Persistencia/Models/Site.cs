using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeatWise_Sprint_2.Net.Persistencia.Models
{
    [Table("Site")]
    public class Site
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome do site é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do site deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(255, ErrorMessage = "A URL do site deve conter no máximo 255 caracteres.")]
        public string URL { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome de usuário deve conter no máximo 50 caracteres.")]
        public string Usuario { get; set; }

        // Relacionamento com Empresa
        [ForeignKey("Empresa")]
        public long EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
