using VehicleAllocation.Api.DTOs;
using VehicleAllocation.Api.DTOs.Requests;
using VehicleAllocation.Api.DTOs.Responses;
using VehicleAllocation.Api.Services;

namespace VehicleAllocation.Api.Endpoints
{
    public static class Allocation
    {
        public static void AddAllocateVehicleEndpoints(this WebApplication app)
        {
            //Gets available and occupied number of spaces
            app.MapGet("/parking", async (IAllocationService allocationService) =>
            {
                var status = await allocationService.GetAllocationStatus();

                return Results.Ok(new AllocationStatus { AvailableSpaces = status.AvailableSpaces, OccupiedSpaces = status.OccupiedSpaces });
            });

            //Parks a given vehicle in the first available space and returns the vehicle and its space number
            app.MapPost("/parking", async (AllocationRequest request, IAllocationService allocationService) =>
            {
                try
                {
                    if (!VahicleTypeValid(request))
                    {
                        return Results.BadRequest($"Incorrect car type {request.VehicleType} allowed small, medium or large");
                    }
                    var model = await allocationService.AllocateVehicle(request.VehicleReg, request.VehicleType);

                    return Results.Ok(new AllocationResponse { VehicleReg = model.VehicleReg, SpaceNumber = model.SpaceNumber, TimeIn = model.TimeIn });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            //Free up this vehicles space and return its final charge from its parking time until now 
            app.MapPost("/parking/exit", async (AllocationBase request, IAllocationService allocationService) =>
            {
                try
                {
                    var model = await allocationService.DeallocateVehicle(request.VehicleReg);

                    return Results.Ok(new AllocationExitResponse { VehicleReg = model.VehicleReg, VehicleCharge = model.VehicleCharge, TimeIn = model.TimeIn, TimeOut = model.TimeOut!.Value });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }

        private static bool VahicleTypeValid(AllocationRequest request)
        {
            return request.VehicleType.ToLower() switch
            {
                "small" or "medium" or "large" => true,
                _ => false,
            };
        }
    }
}
