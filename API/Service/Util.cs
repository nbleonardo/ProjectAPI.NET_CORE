using System;

namespace API.Service
{
	public class Util
	{
		/// <summary>
		/// Calcula a diferença entre datas e retorna os anos entre elas.
		/// </summary>
		/// <param name="dtInicial"></param>
		/// <returns></returns>
		public static int CalculaDiffAnos(DateTime dtInicial)
		{
			int anos = DateTime.Now.Year - dtInicial.Year;
			if (DateTime.Now.Month < dtInicial.Month || (DateTime.Now.Month == dtInicial.Month && DateTime.Now.Day < dtInicial.Day))
				anos--;

			return anos;
		}

		/// <summary>
		/// Remove caracteres não numéricos
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string RemoveNaoNumericos(string text)
		{
			System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
			string ret = reg.Replace(text, string.Empty);
			return ret;
		}

		/// <summary>
		/// Valida se um cpf ou cnpj é válido
		/// </summary>
		/// <param name="cpfCnpj"></param>
		/// <returns></returns>
		public static bool ValidaCPFCNPJ(string cpfCnpj)
		{
			cpfCnpj = RemoveNaoNumericos(cpfCnpj);

			if (cpfCnpj.Length > 11)
				return ValidaCNPJ(cpfCnpj);

			return ValidaCPF(cpfCnpj);
		}

		/// <summary>
		/// Realiza a validação de um CPF
		/// </summary>
		/// <param name="cpf"></param>
		/// <returns></returns>
		private static bool ValidaCPF(string cpf)
		{
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;

			if (cpf.Length != 11)
				return false;
			switch(cpf)
			{
				case "11111111111":
					return false;
				case "22222222222":
					return false;
				case "33333333333":
					return false;
				case "44444444444":
					return false;
				case "55555555555":
					return false;
				case "66666666666":
					return false;
				case "77777777777":
					return false;
				case "88888888888":
					return false;
				case "99999999999":
					return false;
			}
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cpf.EndsWith(digito);
		}

		/// <summary>
		/// Realiza a validação do CNPJ
		/// </summary>
		public static bool ValidaCNPJ(string cnpj)
		{
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			if (cnpj.Length != 14)
				return false;

			tempCnpj = cnpj.Substring(0, 12);

			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = resto.ToString();

			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cnpj.EndsWith(digito);
		}
	}
}