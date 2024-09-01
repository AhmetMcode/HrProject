using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Application.Services
{
    public class KaliteBirimAtamaService : BaseRepository<KaliteBirimAtama>, IKaliteBirimAtamaService
    {
        public KaliteBirimAtamaService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public bool AddIlkUser(KaliteBirimAtamaIlkKontrolUser kaliteBirimAtama)
        {
            try
            {
                _context.KaliteBirimAtamaIlkKontrolUser.Add(kaliteBirimAtama);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool AddSonUser(KaliteBirimAtamaSonKontrolUser kaliteBirimAtama)
        {
            try
            {
                _context.KaliteBirimAtamaSonKontrolUser.Add(kaliteBirimAtama);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public KaliteBirimAtama GetUretimYeriInclude(int UretimYeriId)
        {
            var atama = _context.KaliteBirimAtama.Where(x => x.ProductionPlaceId == UretimYeriId).Include(x => x.ProductionPlace).Include(x => x.IlkKontrolUsers).ThenInclude(x => x.IlkKontrolUser).Include(x => x.SonKontrolUsers).ThenInclude(x => x.SonKontrolUser).FirstOrDefault();
            if (atama == null)
            {
                KaliteBirimAtama kaliteBirimAtama = new KaliteBirimAtama();
                kaliteBirimAtama.ProductionPlaceId = UretimYeriId;
                _context.KaliteBirimAtama.Add(kaliteBirimAtama);
                _context.SaveChanges();
                return kaliteBirimAtama;
            }
            return atama;
        }

        public List<ProductionPlace> GetUretimYerleri(string userId)
        {

            var atama = _context.KaliteBirimAtama
           .Include(x => x.IlkKontrolUsers)
           .Include(x => x.SonKontrolUsers)
           .Where(x => x.IlkKontrolUsers.Any(u => u.IlkKontrolUserId == userId)
                    || x.SonKontrolUsers.Any(u => u.SonKontrolUserId == userId))
           .ToList();

            List<ProductionPlace> WareHouse = new List<ProductionPlace>();

            foreach (var item in atama)
            {
                var productionPlace = _context.ProductionPlaces.FirstOrDefault(x => x.Id == item.Id);
                if (productionPlace != null)
                {
                    WareHouse.Add(productionPlace);
                }
            }
            return WareHouse;
        }

        public bool KaliteAtamaSil(string userKontrolId, int KaliteBirimAtamaId, bool ilk)
        {
            var atama = _context.KaliteBirimAtama
                  .Include(x => x.IlkKontrolUsers)
                  .Include(x => x.SonKontrolUsers)
                  .FirstOrDefault(x => x.Id == KaliteBirimAtamaId);

            if (atama == null)
            {
                return false; // Eğer atama bulunamazsa, işlem başarısız.
            }

            if (ilk)
            {
                // İlk kontrol kullanıcılarından ilgili kullanıcıyı bul ve sil.
                var userToRemove = atama.IlkKontrolUsers.FirstOrDefault(x => x.IlkKontrolUserId == userKontrolId);
                if (userToRemove != null)
                {
                    _context.KaliteBirimAtamaIlkKontrolUser.Remove(userToRemove);
                }
                else
                {
                    return false; // Eğer kullanıcı bulunamazsa, işlem başarısız.
                }
            }
            else
            {
                var userToRemove = atama.SonKontrolUsers.FirstOrDefault(x => x.SonKontrolUserId == userKontrolId);
                if (userToRemove != null)
                {
                    _context.KaliteBirimAtamaSonKontrolUser.Remove(userToRemove);
                }
                else
                {
                    return false; // Eğer kullanıcı bulunamazsa, işlem başarısız.
                }
            }

            _context.SaveChanges(); // Değişiklikleri veritabanına kaydedin.
            return true; // İşlem başarılı.
        }
    }
}
