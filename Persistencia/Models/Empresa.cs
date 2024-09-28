using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeatWise_Sprint_2.Net.Persistencia.Models
{
    public enum FormaPagamento
    {
        Cartão,
        Boleto,
        PIX
    }

    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome da empresa deve conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(14, ErrorMessage = "O CNPJ deve conter no máximo 14 caracteres.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O email da empresa é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email da empresa não é válido.")]
        [MaxLength(100, ErrorMessage = "O email da empresa deve conter no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O número de telefone é inválido.")]
        [MaxLength(20, ErrorMessage = "O telefone deve conter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        // Campo de forma de pagamento como enum
        public FormaPagamento FormaPagamento { get; set; }

        // Relacionamento com Plano
        [ForeignKey("Plano")]
        public long PlanoId { get; set; }
        public Plano Plano { get; set; }
    }
}
