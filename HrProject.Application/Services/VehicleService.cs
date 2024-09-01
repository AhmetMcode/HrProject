using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System.Linq.Expressions;

namespace HrProject.Application.Services
{
    public class VehicleService : BaseRepository<Vehicle>, IVehicleService
    {
        public VehicleService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public IEnumerable<Vehicle> GetIncludeVehicle()
        {
            var vehicle = _context.Vehicles.Include(x => x.VehicleWashs).Include(c => c.BackupResponsible).Include(c => c.MainResponsible).Include(c => c.VehicleCategory).ToList();
            return vehicle;
        }

        public bool UpdateWashDate(int id, DateTime yikamaTarihi)
        {
            var wash = _context.VehicleWash.Where(x => x.Id == id).FirstOrDefault();
            wash.WashDate = yikamaTarihi;
            _context.VehicleWash.Update(wash);
            _context.SaveChanges();
            return true;
        }

        public bool YikamaEkle(VehicleWash vehicleWash)
        {
            try
            {
                _context.VehicleWash.Add(vehicleWash);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void AddKilometerUpdate(VehicleKilometerUpdate kilometerUpdate)
        {
            _context.VehicleKilometerUpdate.Add(kilometerUpdate);
            _context.SaveChanges();
        }

        public VehicleKilometerUpdate GetLastKilometerUpdate(int vehicleId)
        {
            return _context.VehicleKilometerUpdate
                .Include(k => k.ApplicationUser)
                .Where(k => k.VehicleId == vehicleId)
                .OrderByDescending(k => k.UpdateDate)
                .FirstOrDefault()
                ?? throw new Exception("No kilometer update found for the specified vehicle.");
        }

        public bool LendVehicle(VehicleLend vehicleLend)
        {
            try
            {
                _context.VehicleLend.Add(vehicleLend);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<VehicleLend> GetAllVehicleLends()
        {
            return _context.VehicleLend
                .Include(vl => vl.Vehicle)
                .Include(vl => vl.ApplicationUser)
                .Include(vl => vl.Person)
                .Include(vl => vl.LenderUser)
                .ToList();
        }
        public ApplicationUser GetUserById(string userId)
        {
            return _context.ApplicationUsers.Find(userId);
        }

        public Person GetPersonById(int personId)
        {
            return _context.Personals.Find(personId);
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            return _context.Vehicles.Find(vehicleId);
        }
    }
}
