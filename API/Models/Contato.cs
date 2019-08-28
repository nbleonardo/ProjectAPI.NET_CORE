using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Contato
	{
		public int Id { get; set; }
		public int IdCliente { get; set; }

		[Required(ErrorMessage = "Nome do contato deve ser informado")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Telefone deve ser informado")]
		public string Telefone { get; set; }
	}
}
