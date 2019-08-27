﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
	public class ContaBancaria
	{
		public int Id { get; set; }
		[ForeignKey("IdCliente")]
		public Cliente Client { get; set; }
		public int IdCliente { get; set; }
		[Required(ErrorMessage = "Nome do banco deve ser informado")]
		[DisplayName("Nome do Banco")]
		public string NomeBanco { get; set; }
		[Required(ErrorMessage = "Número da Agéncia Bancária deve ser informado")]
		[DisplayName("Número da Agéncia Bancária")]
		public string Agencia { get; set; }
		[Required(ErrorMessage = "Número da Conta Bancária deve ser informado")]
		[DisplayName("Número da Conta Bancária")]
		public string Conta { get; set; }
	}
}
