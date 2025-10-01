using VehicleAllocation.Api.Services;
using VehicleAllocation.SQL;
using VehicleAllocation.SQL.Extensions;

namespace VehicleAllocation.Api.Extensions
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection serviceCollection, IConfiguration configurationRoot)
        {
            var sqlConnectionString = configurationRoot.GetConnectionString(nameof(VehicleContext));
            serviceCollection.AddVehicleAllocationContext(sqlConnectionString);

            serviceCollection.AddScoped<IAllocationService, AllocationService>();
        }
    }
}
