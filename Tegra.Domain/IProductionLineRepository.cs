using System.Collections.Generic;
using System.Threading.Tasks;
using Tegra.Domain.Models;

namespace Tegra.Domain
{
    public interface IProductionLineRepository
    {
        Task<IEnumerable<AddressPpm>> GetProductionLines();
        Task<AddressPpm> GetProductionLine(int id);
    }
}