
using VehicleAllocation.Api.DTOs.Responses;
using VehicleAllocation.SQL.Models;

namespace VehicleAllocation.Api.Services
{
    public interface IAllocationService
    {
        /// <summary>
        /// Get the status of the parking
        /// </summary>
        /// <returns></returns>
        Task<AllocationStatus> GetAllocationStatus();

        /// <summary>
        /// Allocate vehicle in the parking if possible 
        /// </summary>
        /// <param name="vehicleReg"></param>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        Task<VehicleAllocationDbModel> AllocateVehicle(string vehicleReg, string vehicleType);

        /// <summary>
        /// Deallocate vehicle from parking
        /// </summary>
        /// <param name="vehicleReg"></param>
        /// <returns></returns>
        Task<VehicleAllocationDbModel> DeallocateVehicle(string vehicleReg);
    }
}
