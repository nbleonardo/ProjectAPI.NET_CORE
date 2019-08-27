using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Context _context;

        public ClienteController(Context context)
        {
            _context = context;

            if (_context.Clientes.Count() == 0)
            {
                _context.Clientes.Add(
                    new Cliente
                    {
                        Id = 1,
                        Nome = "Usuário 1",
                        CpfCnpj = "270.494.640-07",
                        Data = new DateTime(2019, 5, 20),
                        Sexo = "Masculino",
                        ProfissaoAtividade = "Teste",
                        Contatos = new List<Contato>{ new Contato {
                            Id = 1,
                            IdCliente = 1,
                            Nome = "Contato 1",
                            Telefone = "5199887766"
                        } },
                        Email = "teste@teste.com.br",
                        Endereco = new Endereco
                        {
                            Id = 1,
                            IdCliente = 1,
                            Logradouro = "Rua Teste",
                            Numero = "123",
                            Bairro = "Teste B",
                            CEP = "97414-100",
                            Cidade = "Porto Alegre"
                        },
                        DadosBancarios = new ContaBancaria
                        {
                            Id = 1,
                            IdCliente = 1,
                            NomeBanco = "Teste Banco",
                            Agencia = "0123",
                            Conta = "012365"
                        }
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await (from client in _context.Clientes 
                         select new Cliente
                         {
                             Id = client.Id,
                             Nome = client.Nome,
                             CpfCnpj = client.CpfCnpj,
                             Data = client.Data,
                             ProfissaoAtividade = client.ProfissaoAtividade,
                             Contatos = _context.Contatos.Where(x=>x.IdCliente == client.Id).ToList(),
                             Email = client.Email,
                             Endereco = _context.Enderecos.Where(x=>x.IdCliente == client.Id).FirstOrDefault(),
                             DadosBancarios = _context.ContasBancarias.Where(x=>x.IdCliente == client.Id).FirstOrDefault(),
                             Ativo = client.Ativo,
                             DataDesativado = client.DataDesativado
                         })
                         .ToListAsync();
        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
