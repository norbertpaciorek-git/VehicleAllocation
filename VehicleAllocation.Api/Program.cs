using VehicleAllocation.Api.Endpoints;
using VehicleAllocation.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddServices(builder.Configuration);

var app = builder.Build();
app.UseStatusCodePages();
app.AddAllocateVehicleEndpoints();

app.Run();



