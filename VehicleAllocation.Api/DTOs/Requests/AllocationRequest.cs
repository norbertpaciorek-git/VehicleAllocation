namespace VehicleAllocation.Api.DTOs.Requests
{
    public class AllocationRequest : AllocationBase
    {
        public required string VehicleType { get; set; } //This could be enum not string 
    }
}
