using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tegra.Domain;
using Tegra.Domain.Models;

namespace Tegra.Infrastructure.Data
{
    class InMemoryProductionLineRepository : IProductionLineRepository
    {
        private readonly List<AddressPpm> _data;

        public InMemoryProductionLineRepository()
        {
            _data = Enumerable.Range(1,50).Select(x=>new AddressPpm()
            {
                AddressPpmId = x,
                CompanyName = "EB-"+x,
                CompanyNumber = "EB-01"
            }).ToList();
        }
        public Task<IEnumerable<AddressPpm>> GetProductionLines()
        {
            return Task.FromResult(_data.AsEnumerable());
        }

        public Task<AddressPpm> GetProductionLine(int id)
        {
            return Task.FromResult(_data.FirstOrDefault(x => x.AddressPpmId == id));
        }
    }
}
