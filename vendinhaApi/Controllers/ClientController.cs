using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vendinhaApi.Models;

namespace vendinhaApi.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientController (DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> Get()
        {

            return Ok(await _context.Clients.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            _context.SaleList.Add(
                new SaleList
                {
                    ClientId = client.Id,
                }
            );
            await _context.SaveChangesAsync();
            return Ok(client);
        }

        [HttpPut]
        public async Task<ActionResult<List<Client>>> UpdateClient(Client request)
        {
            var dbClient = await _context.Clients.FindAsync(request.Id);
            if (dbClient == null)
            {
                return NotFound();
            }
            dbClient.Name = request.Name;
            dbClient.Cpf = request.Cpf;
            dbClient.Birth_date = request.Birth_date;
            dbClient.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(dbClient);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Client>>> DeleteClient(int id)
        {
            var dbClient = await _context.Clients.FindAsync(id);
            var dbSaleList = await _context.SaleList.Where(a => a.ClientId == id).FirstAsync();
            if (dbClient == null || dbSaleList == null)
            {
                return NotFound();
            }
            _context.SaleList.Remove(dbSaleList);
            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();
            return Ok(dbClient);
        }


    }
}
