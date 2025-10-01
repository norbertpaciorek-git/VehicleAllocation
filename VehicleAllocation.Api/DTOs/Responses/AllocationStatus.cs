namespace VehicleAllocation.Api.DTOs.Responses
{
    public class AllocationStatus
    {
        public required int AvailableSpaces { get; set; }
        public required int OccupiedSpaces { get; set; }
    }
}
