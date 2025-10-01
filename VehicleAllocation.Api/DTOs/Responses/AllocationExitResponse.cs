namespace VehicleAllocation.Api.DTOs.Responses
{
    public class AllocationExitResponse : AllocationBase
    {
        public required double VehicleCharge { get; set; }
        public required DateTime TimeIn { get; set; }
        public required DateTime TimeOut { get; set; }
    }
}
