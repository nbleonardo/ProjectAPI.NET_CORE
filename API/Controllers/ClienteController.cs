using API.Models;
using API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

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
                _context.Clientes.Add(
                    new Cliente
                    {
                        Id = 2,
                        Nome = "Usuário 2",
                        CpfCnpj = "270.494.640-70",
                        Data = new DateTime(2019, 2, 21),
                        Sexo = "Masculino",
                        ProfissaoAtividade = "Teste",
                        Contatos = new List<Contato>{ new Contato {
                            Id = 2,
                            IdCliente = 2,
                            Nome = "Contato 1",
                            Telefone = "5199887766"
                        } },
                        Email = "teste@teste.com.br",
                        Endereco = new Endereco
                        {
                            Id = 2,
                            IdCliente = 2,
                            Logradouro = "Rua Teste",
                            Numero = "123",
                            Bairro = "Teste B",
                            CEP = "97414-100",
                            Cidade = "Porto Alegre"
                        },
                        DadosBancarios = new ContaBancaria
                        {
                            Id = 2,
                            IdCliente = 2,
                            NomeBanco = "Teste Banco",
                            Agencia = "0123",
                            Conta = "012365"
                        },
                        Ativo = false,
                        DataDesativado = new DateTime(2015, 2, 21)
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await (from client in _context.Clientes
                          where client.DataDesativado == null || Util.CalculaDiffAnos(client.DataDesativado.Value) <= 2
                         select new Cliente
                         {
                             Id = client.Id,
                             Nome = client.Nome,
                             CpfCnpj = client.CpfCnpj,
                             Data = client.Data,
                             Sexo = client.Sexo,
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
        public async Task<ActionResult<Cliente>> Get(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Contatos = _context.Contatos.Where(x => x.IdCliente == id).ToList();
            cliente.Endereco = _context.Enderecos.Where(x => x.IdCliente == id).FirstOrDefault();
            cliente.DadosBancarios = _context.ContasBancarias.Where(x => x.IdCliente == id).FirstOrDefault();
            return cliente;
        }

        // POST: api/Cliente
        [HttpPost]
        public HttpResponseMessage Post(Cliente item)
        {
            _context.Clientes.Add(item);
            _context.SaveChangesAsync();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Cliente item)
        {
            if (id != item.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var todoItem = await _context.Clientes.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
