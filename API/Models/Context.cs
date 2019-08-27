using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
		public DbSet<ContaBancaria> ContasBancarias { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Contato> Contatos { get; set; }
	}
}