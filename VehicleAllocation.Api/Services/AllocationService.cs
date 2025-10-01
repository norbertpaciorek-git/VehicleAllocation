using Microsoft.EntityFrameworkCore;
using VehicleAllocation.Api.DTOs.Responses;
using VehicleAllocation.SQL;
using VehicleAllocation.SQL.Models;

namespace VehicleAllocation.Api.Services
{
    public class AllocationService : IAllocationService
    {
        private readonly VehicleContext _context;

        public AllocationService(VehicleContext context)
        {
            _context = context;
            _context.Database.EnsureCreated(); //Need to call it to make sure data is seeded. 
        }

        public async Task<AllocationStatus> GetAllocationStatus()
        {
            var spaces = await _context.ParkingSpacesModel.ToListAsync();

            var allSpaces = spaces.Count();
            var occupied = spaces.Where(x => x.IsBusy).Count();
            var availableSpaces = allSpaces - occupied;

            return new AllocationStatus { AvailableSpaces = availableSpaces, OccupiedSpaces = occupied };
        }

        public async Task<VehicleAllocationDbModel> AllocateVehicle(string vehicleReg, string vehicleType)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            //find first available space 
            var freeSpace = _context.ParkingSpacesModel.OrderBy(x => x.SpaceNumber).FirstOrDefault(x => !x.IsBusy) ?? throw new Exception("Parking is full no more spaces!");
            
            if (_context.VehicleAllocationModel.FirstOrDefault(x => x.VehicleReg.Equals(vehicleReg)) != null)
            {
                throw new Exception("Car with the same registration number already exists");
            }

            var model = new VehicleAllocationDbModel
            {
                SpaceNumber = freeSpace.SpaceNumber,
                TimeIn = DateTime.Now,
                VehicleType = vehicleType,
                VehicleReg = vehicleReg
            };

            freeSpace.IsBusy = true;

            _context.Add(model);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return model;
        }

        public async Task<VehicleAllocationDbModel> DeallocateVehicle(string vehicleReg)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            var vehicle = _context.VehicleAllocationModel.FirstOrDefault(x => x.VehicleReg.Equals(vehicleReg)) ?? throw new Exception($"Car with the registration provided {vehicleReg} does not exists");
            
            vehicle.CalculateCost();
            vehicle.Archived = true;

            _context.ParkingSpacesModel.First(x => x.SpaceNumber == vehicle.SpaceNumber).IsBusy = false;
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return vehicle;
        }
    }
}
