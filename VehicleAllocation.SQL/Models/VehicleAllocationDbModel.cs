
namespace VehicleAllocation.SQL.Models
{
    public class VehicleAllocationDbModel : BaseEntity
    {
        public string VehicleReg { get; set; } = string.Empty;
        public string VehicleType { get; set; } = string.Empty;

        public double VehicleCharge { get; set; }
        public int SpaceNumber { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }

        public bool Archived { get; set; }

        public void CalculateCost()
        {
            TimeOut = DateTime.Now;

            //calculate total minutes between timeIn and out 
            TimeSpan span = TimeOut.Value.Subtract(TimeIn);

            //Every 5 minutes an additional charge of £1 will be added 
            var additionalCharge = Math.Round(span.TotalMinutes / 5, 0, MidpointRounding.AwayFromZero);

            //calculate charge by car type
            var charge = GetFee() * span.TotalMinutes;

            VehicleCharge = charge + additionalCharge;
        }

        private double GetFee()
        {
            switch (VehicleType.ToLower())
            {
                case "small":
                    return 0.1;
                case
                    "medium":
                    return 0.2;
                case
                    "large":
                    return 0.4;
                default:
                    break;
            }
            return 0;
        }
    }
}
