using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Cliente
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Nome / Razão social de ser prenchido")]
		[StringLength(200, ErrorMessage = "São permitidos no máximo 200 caracteres.")]
		[DisplayName("Nome / Razão social")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "CPF / CNPJ deve ser preenchido")]
		[DisplayName("CPF / CNPJ")]
		public string CpfCnpj { get; set; }

		[Required(ErrorMessage = "Data deve ser preenchida")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		[DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada!")]
		public DateTime? Data { get; set; }

		public string Sexo { get; set; }

		[Required(ErrorMessage = "Profissão / Atividades Econômicas deve ser preenchido")]
		[DisplayName("Profissão / Atividades Econômicas")]
		public string ProfissaoAtividade { get; set; }

        [DisplayName("Lista de contatos Telefônicos")]
		public virtual ICollection<Contato> Contatos { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
		[DisplayName("E-mail")]
		public string Email { get; set; }

		public virtual Endereco Endereco { get; set; }
		public virtual ContaBancaria DadosBancarios { get; set; }
        
        [DefaultValue(true)]
        public bool Ativo { get; set; } = true;

		public DateTime? DataDesativado { get; set; }


        public Cliente()
        {
            Contatos = new HashSet<Contato>();
            DadosBancarios = new ContaBancaria();
            Endereco = new Endereco();
        }
    }
}
