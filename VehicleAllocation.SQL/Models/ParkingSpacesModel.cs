namespace VehicleAllocation.SQL.Models
{
    public class ParkingSpacesModel : BaseEntity
    {
        public int SpaceNumber { get; set; }
        public bool IsBusy { get; set; }
    }
}
