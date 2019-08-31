using API.Service;
using System.ComponentModel.DataAnnotations;

namespace API.Validations
{
	/// <summary>
	/// Validação customizada para CPF e CNPJ
	/// </summary>
	public class CustomValidationCPFCNPJAttribute : ValidationAttribute
	{
		/// <summary>
		/// Construtor
		/// </summary>
		public CustomValidationCPFCNPJAttribute() { }

		/// <summary>
		/// Validação server
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public override bool IsValid(object value)
		{
			if (value == null || string.IsNullOrEmpty(value.ToString()))
				return false;

			return Util.ValidaCPFCNPJ(value.ToString());
		}
	}
}