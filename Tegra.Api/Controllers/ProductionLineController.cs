using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tegra.Api.Services;
using Tegra.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tegra.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductionLineController : Controller
    {
        private readonly IProductionLineService _productionLineService;
        public ProductionLineController(IProductionLineService productionLineService)
        {
            _productionLineService = productionLineService;
        }
        // GET: api/<controller>
        [HttpGet]
        public async  Task<IEnumerable<ProductionLine>> Get()
        {
            return await _productionLineService.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ProductionLine> Get(int id)
        {
            return await _productionLineService.Get(id);

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
