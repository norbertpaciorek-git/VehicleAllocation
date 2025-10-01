namespace VehicleAllocation.Api.DTOs.Responses
{
    public class AllocationResponse : AllocationBase
    {
        public required int SpaceNumber { get; set; }
        public required DateTime TimeIn { get; set; }
    }
}
