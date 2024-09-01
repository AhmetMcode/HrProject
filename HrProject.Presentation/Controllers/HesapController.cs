using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.ViewModels;

namespace HrProject.Presentation.Controllers
{
    public class HesapController : Controller
    {
        private readonly IHesapSiniflariService hesapSiniflariService;
        private readonly IHesapGruplariService hesapGruplariService;
        private readonly IHesapPlaniService hesapPlaniService;
        private readonly IHesapMuavinService hesapMuavinService;
        private readonly IHesapTaliService hesapTaliService;
        private readonly IHesapDetayService hesapDetayService;
        private readonly IMapper mapper;

        public HesapController(IHesapSiniflariService hesapSiniflariService, IHesapGruplariService hesapGruplariService, IHesapPlaniService hesapPlaniService, IHesapMuavinService hesapMuavinService, IHesapTaliService hesapTaliService, IHesapDetayService hesapDetayService, IMapper mapper)
        {
            this.hesapSiniflariService = hesapSiniflariService;
            this.hesapGruplariService = hesapGruplariService;
            this.hesapPlaniService = hesapPlaniService;
            this.hesapMuavinService = hesapMuavinService;
            this.hesapTaliService = hesapTaliService;
            this.hesapDetayService = hesapDetayService;
            this.mapper = mapper;
        }




        public IActionResult HesapList()
        {
            // Servis kullanılarak verileri çek
            var hesapSiniflaris = hesapSiniflariService.GetAllHesapSiniflar();

            // HesapViewModel'e verileri yükle
            var hesapViewModel = new HesapViewModel
            {
                HesapSiniflaris = hesapSiniflaris
            };

            // View'e ViewModel'i gönder
            return View(hesapViewModel);
        }




        [HttpPost]
        public IActionResult UpdateHesapGruplari(HesapGruplari hesapGruplari)

        {
            HesapGruplari hesap = hesapGruplariService.GetById(hesapGruplari.Id);


            hesap.HesapName = hesapGruplari.HesapName;
            hesapGruplariService.Update(hesap);

            return RedirectToAction("HesapList");
        }

        [HttpPost]
        public IActionResult UpdateHesapPlani(HesapPlani hesapPlani)

        {
            HesapPlani hesap = hesapPlaniService.GetById(hesapPlani.Id);


            hesap.HesapName = hesapPlani.HesapName;
            hesapPlaniService.Update(hesap);

            return RedirectToAction("HesapList");
        }

        [HttpPost]
        public IActionResult UpdateHesapMuavin(HesapMuavin hesapMuavin)

        {
            HesapMuavin hesap = hesapMuavinService.GetById(hesapMuavin.Id);


            hesap.HesapCode = hesapMuavin.HesapCode;
            hesap.HesapName = hesapMuavin.HesapName;

            hesapMuavinService.Update(hesap);

            return RedirectToAction("HesapList");
        }

        //[HttpPost]
        //public IActionResult AddHesapMuavin(HesapMuavin hesapMuavin)
        //{
        //    // Kod veya ad aynı olan başka bir hesapMuavin var mı kontrol et
        //    if (hesapMuavinService.IsCodeOrNameExists(hesapMuavin.HesapPlaniId, hesapMuavin.HesapCode, hesapMuavin.HesapName))
        //    {
        //        // Aynı hesapMuavin adı veya kodu zaten var, kullanıcıyı uyar

        //        //ViewBag.ErrorMessage = "Aynı Muavin Hesap adı veya kodu kullanılamaz.";
        //        ModelState.AddModelError(string.Empty, "Aynı hesapMuavin kodu kullanılamaz.");
        //        return View("HesapList", hesapMuavin);
        //    }

        //    hesapMuavin.HesapPlani = null;
        //    hesapMuavinService.Insert(hesapMuavin);

        //    return RedirectToAction("HesapList");
        //}



        //HesapMuavin hesap = mapper.Map<HesapViewModel2,HesapMuavin>(MuavinVM);

        [HttpPost]
        public IActionResult AddHesapMuavin(HesapViewModel MuavinVM)
        {

            if (!hesapMuavinService.IsCodeOrNameExists(MuavinVM.HesapPlaniId, MuavinVM.HesapCode, MuavinVM.HesapName))
            {
                HesapMuavin hesapVM = new HesapMuavin
                {
                    Id = MuavinVM.Id,
                    HesapName = MuavinVM.HesapName,
                    HesapCode = MuavinVM.HesapCode,
                    HesapPlaniId = MuavinVM.HesapPlaniId,
                    HesapPlani = null,
                };
                hesapMuavinService.Insert(hesapVM);
                return RedirectToAction("HesapList");
            }
            else
            {

                //ViewBag.ErrorMessage = "Aynı Muavin Hesap adı veya kodu kullanılamaz.";
                ModelState.AddModelError(string.Empty, "Aynı hesapMuavin kodu kullanılamaz.");
                return View("HesapList", MuavinVM);


            }

        }


        public IActionResult DeleteHesapMuavin(int muavinId)
        {
            try
            {
                hesapMuavinService.Delete(muavinId);

                return Json("Ürün başarıyla silindi.");
            }
            catch (Exception ex)
            {
                // Silme işlemi sırasında bir hata olursa
                return Json("Silme işlemi başarısız");
            }

        }


        [HttpPost]
        public IActionResult UpdateHesapTali(HesapTali hesapTali)

        {
            HesapTali hesap = hesapTaliService.GetById(hesapTali.Id);


            hesap.HesapCode = hesapTali.HesapCode;
            hesap.HesapName = hesapTali.HesapName;

            hesapTaliService.Update(hesap);

            return RedirectToAction("HesapList");
        }


        [HttpPost]
        public IActionResult AddHesapTali(HesapTali hesapTali)
        {

            hesapTali.HesapMuavin = null;
            hesapTaliService.Insert(hesapTali);
            return RedirectToAction("HesapList");
        }

        public IActionResult DeleteHesapTali(int taliId)
        {
            try
            {
                hesapTaliService.Delete(taliId);

                return Json("Ürün başarıyla silindi.");
            }
            catch (Exception ex)
            {
                // Silme işlemi sırasında bir hata olursa
                return Json("Silme işlemi başarısız");
            }

        }
        [HttpPost]
        public IActionResult UpdateHesapDetay(HesapDetay hesapDetay)

        {
            HesapDetay hesap = hesapDetayService.GetById(hesapDetay.Id);


            hesap.HesapCode = hesapDetay.HesapCode;
            hesap.HesapName = hesapDetay.HesapName;

            hesapDetayService.Update(hesap);

            return RedirectToAction("HesapList");
        }

        [HttpPost]
        public IActionResult AddHesapDetay(HesapDetay hesapDetay)
        {

            hesapDetay.HesapTali = null;
            hesapDetayService.Insert(hesapDetay);
            return RedirectToAction("HesapList");
        }

        public IActionResult DeleteHesapDetay(int detayId)
        {
            try
            {
                hesapDetayService.Delete(detayId);

                return Json("Ürün başarıyla silindi.");
            }
            catch (Exception ex)
            {
                // Silme işlemi sırasında bir hata olursa
                return Json("Silme işlemi başarısız");
            }

        }




    }
}
