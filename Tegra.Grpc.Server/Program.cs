using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Tegra.Domain;
using Tegra.Infrastructure.IoC;
using Tegra.Services;


namespace Tegra.Grpc.Server
{
    class ProductionLineImpl : ProductionLineService.ProductionLineServiceBase
    {
        private readonly IServiceProvider _serviceProvider;
        public ProductionLineImpl(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public override async Task<ProductionLineResponse> GetProductionLine(ProductionLineRequest request, ServerCallContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var repo = scope.ServiceProvider.GetService<IProductionLineRepository>();
                var result = await repo.GetProductionLine(request.Id);
                return new ProductionLineResponse()
                {
                    Result = new ProductionLine()
                    {
                        Id = result.AddressPpmId,
                        Building = result.CompanyNumber,
                        Name = result.CompanyName
                    }
                };
            }
        }

        public override async Task<ProductionLinesResponse> GetProductionLines(ProductionLinesRequest request,
            ServerCallContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    
                    var repo = _serviceProvider.GetService<IProductionLineRepository>();
                    var result = (await repo.GetProductionLines()).Select(r =>
                        new ProductionLine()
                        {
                            Id = r.AddressPpmId,
                            Building = r.CompanyNumber,
                            Name = r.CompanyName
                        }
                    ).ToArray();
                    return new ProductionLinesResponse()
                    {
                        Result = {result}
                    };
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddInfrastructure()
                .BuildServiceProvider();

            var server = new global::Grpc.Core.Server
            {
                Services = { ProductionLineService.BindService(new ProductionLineImpl(serviceProvider)) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Production Line server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
