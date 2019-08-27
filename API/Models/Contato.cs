using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
