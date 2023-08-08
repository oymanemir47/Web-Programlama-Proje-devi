using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUygulama1.Models;
using WebUygulama1.Utility;

namespace WebUygulama1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class HayvanTuruController : Controller
    {
        private readonly IHayvanTuruRepository _hayvanTuruRepository;

        public HayvanTuruController(IHayvanTuruRepository context)
        {
            _hayvanTuruRepository = context;
        }


        public IActionResult Index()
        {
            List<HayvanTuru> obHayvanTuruList = _hayvanTuruRepository.GetAll().ToList();


            return View(obHayvanTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(HayvanTuru hayvanTuru)
        {




            if (ModelState.IsValid)
            {
                _hayvanTuruRepository.Ekle(hayvanTuru);
                _hayvanTuruRepository.Kaydet(); // savechamges ile bilgiler veritabanına eklenir.
                TempData["basarili"] = "Yeni Hayvan Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "HayvanTuru");
            }
            return View();
        }



        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HayvanTuru? hayvanTuruVt = _hayvanTuruRepository.Get(u=>u.Id==id);
            if (hayvanTuruVt == null)
            {
                return NotFound();
            }
            return View(hayvanTuruVt);
        }
        [HttpPost]
        public IActionResult Guncelle(HayvanTuru hayvanTuru)
        {




            if (ModelState.IsValid)
            {
                _hayvanTuruRepository.Guncelle(hayvanTuru);
                _hayvanTuruRepository.Kaydet(); // savechamges ile bilgiler veritabanına eklenir.
                TempData["basarili"] = "Yeni Hayvan Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "HayvanTuru");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HayvanTuru? hayvanTuruVt = _hayvanTuruRepository.Get(u => u.Id == id);
            if (hayvanTuruVt == null)
            {
                return NotFound();
            }
            return View(hayvanTuruVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {

            HayvanTuru? hayvanTuru = _hayvanTuruRepository.Get(u => u.Id == id);
            if (hayvanTuru == null)
            {
                return NotFound();
            }

            _hayvanTuruRepository.Sil(hayvanTuru);
            _hayvanTuruRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "HayvanTuru");





        }
    }
}
