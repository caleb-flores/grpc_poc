using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tegra.Services;

namespace Tegra.Api.Services
{
    public interface IProductionLineService:IDisposable
    {
        Task<IEnumerable<ProductionLine>> GetAll();
        Task<ProductionLine> Get(int id);
    }
}
