using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IVehicleService : IBaseRepository<Vehicle>
    {
        public IEnumerable<Vehicle> GetIncludeVehicle();
        public bool YikamaEkle(VehicleWash vehicleWash);
        public bool UpdateWashDate(int id, DateTime yikamaTarihi);
        void AddKilometerUpdate(VehicleKilometerUpdate kilometerUpdate);
        // Son kilometre güncellemesini almak için yeni metod
        VehicleKilometerUpdate GetLastKilometerUpdate(int vehicleId);
        public bool LendVehicle(VehicleLend vehicleLend);
        IEnumerable<VehicleLend> GetAllVehicleLends();
        ApplicationUser GetUserById(string userId);
        Person GetPersonById(int personId);
        Vehicle GetVehicleById(int vehicleId);
    }
}
