using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using vendinhaApi.Models;

namespace vendinhaApi.Controllers
{
    [Route("api/saleList")]
    [ApiController]
    public class SaleListController : ControllerBase
    {
        private readonly DataContext _context;
        public SaleListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleList>>> Get()
        {

            return Ok(await _context.SaleList.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleList>> Get(int id)
        {
            var dbSaleList  =  await _context.SaleList.Where(a => a.ClientId == id).FirstAsync();
            if (dbSaleList == null)
            {   
                return NotFound();
            }
            return Ok(dbSaleList);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(SaleList list)
        {
            _context.SaleList.Add(list);
            await _context.SaveChangesAsync();
            return Ok(list);
        }

        [HttpPut]
        public async Task<ActionResult<List<SaleList>>> UpdateSaleList(SaleList request)
        {
            var dbSaleList = await _context.SaleList.Where(a => a.ClientId == request.ClientId).FirstAsync();

            if (dbSaleList == null)
            {
                return NotFound();
            }
            dbSaleList.Value = request.Value;
            dbSaleList.IsPaid = request.IsPaid;
            dbSaleList.CreationDate = request.CreationDate;
            dbSaleList.PaymentDate = request.PaymentDate;

            await _context.SaveChangesAsync();

            return Ok(dbSaleList);
        }

    }
}
