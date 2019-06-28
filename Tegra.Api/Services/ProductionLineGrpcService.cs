using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Tegra.Services;

namespace Tegra.Api.Services
{
    public class ProductionLineGrpcService : IProductionLineService
    {
        private readonly ProductionLineService.ProductionLineServiceClient _client;
        private readonly Channel _channel;
        public ProductionLineGrpcService()
        {
            _channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            _client = new ProductionLineService.ProductionLineServiceClient(_channel);
        }
        public async Task<IEnumerable<ProductionLine>> GetAll()
        {
            return (await _client.GetProductionLinesAsync(new ProductionLinesRequest())).Result;
        }

        public async Task<ProductionLine> Get(int id)
        {
            return (await _client.GetProductionLineAsync(new ProductionLineRequest()
            {
                Id = id
            })).Result;
        }

        public void Dispose()
        {
            //_channel.ShutdownAsync().Wait();
        }
    }
}
