﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
	public class Endereco
	{
		public int Id { get; set; }

		[ForeignKey("IdCliente")]
		public Cliente Client { get; set; }
		public int IdCliente { get; set; }
		[Required]
		[DisplayName("Logradouro")]
		public string Logradouro { get; set; }
		[Required]
		[DisplayName("Bairro")]
		public string Bairro { get; set; }
		[Required]
		[DisplayName("Cidade")]
		public string Cidade { get; set; }
		[Required]
		[DisplayName("CEP")]
		public string CEP { get; set; }
		[Required]
		[DisplayName("Número do Apto / Casa")]
		public string Numero { get; set; }
	}
}