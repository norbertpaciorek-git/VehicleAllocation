using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleAllocation.SQL.Models;

namespace VehicleAllocation.SQL.Extensions
{
    public static class DbContextExtension
    {
        public static void AddVehicleAllocationContext(this IServiceCollection services, string? sqlConnectionString)
        {
            if (string.IsNullOrEmpty(sqlConnectionString))
            {
                throw new Exception("SQL connection string cannot be empty for vehicle database");
            }

            services.AddDbContext<VehicleContext>((options) =>
            {
                options.UseSqlServer(sqlConnectionString);
                options.EnableSensitiveDataLogging(false);

                options.UseSeeding((context, _) =>
                {
                    if (!context.Set<ParkingSpacesModel>().Any())
                    {
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 1, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 2, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 3, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 4, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 5, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 6, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 7, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 8, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 9, IsBusy=true });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 10, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 11, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 12, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 13, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 14, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 15, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 16, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 17, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 18, IsBusy=false });
                        context.Set<ParkingSpacesModel>().Add(new ParkingSpacesModel { SpaceNumber = 19, IsBusy=false });
                        context.SaveChanges();
                    }


                    if (context.Set<VehicleAllocationDbModel>().Any())
                    {
                        return; //data already exists no seeding is needed 
                    }

                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration1", VehicleType = "Small", SpaceNumber = 1, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-2) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration2", VehicleType = "Small", SpaceNumber = 2, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-5) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration3", VehicleType = "Small", SpaceNumber = 3, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-10) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration4", VehicleType = "Small", SpaceNumber = 4, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-15) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration5", VehicleType = "Large", SpaceNumber = 5, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-20) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration6", VehicleType = "Large", SpaceNumber = 6, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-25) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration7", VehicleType = "Large", SpaceNumber = 7, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-30) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration8", VehicleType = "Small", SpaceNumber = 8, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-35) });
                    context.Set<VehicleAllocationDbModel>().Add(new VehicleAllocationDbModel { VehicleReg = "Registration9", VehicleType = "Medium",  SpaceNumber = 9, VehicleCharge = 0, TimeIn = DateTime.Now.AddMinutes(-11) });
                    context.SaveChanges();
                });
            });
        }
    }
}
