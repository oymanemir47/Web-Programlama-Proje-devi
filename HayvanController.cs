using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUygulama1.Models;
using WebUygulama1.Utility;

namespace WebUygulama1.Controllers
{
    [Authorize(Roles =UserRoles.Role_Admin)]
    public class HayvanController : Controller
    {
        private readonly IHayvanRepository _hayvanRepository;
        private readonly IHayvanTuruRepository _hayvanTuruRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HayvanController(IHayvanRepository hayvanRepository, IHayvanTuruRepository hayvanTuruRepository, IWebHostEnvironment webHostEnvironment)
        {
            _hayvanRepository = hayvanRepository;
            _hayvanTuruRepository = hayvanTuruRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
           // List<Hayvan> obHayvanList = _hayvanRepository.GetAll().ToList();
            List<Hayvan> obHayvanList = _hayvanRepository.GetAll(includeProps:"HayvanTuru").ToList();




            return View(obHayvanList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> HayvanTuruList = _hayvanTuruRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.Ad,
                    Value = k.Id.ToString()
                });

            ViewBag.HayvanTuruList = HayvanTuruList;
            if(id == null || id == 0)
            {
                // ekle
                return View();
            }else
            { // guncelle
                Hayvan? hayvanVt = _hayvanRepository.Get(u => u.Id == id);
                if (hayvanVt == null)
                {
                    return NotFound();
                }
                return View(hayvanVt);
            }

            
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Hayvan hayvan, IFormFile? file)
        {
           



            if (ModelState.IsValid)
            {

              string wwwRootPath = _webHostEnvironment.WebRootPath;
              string hayvanPath = Path.Combine(wwwRootPath, @"img");


                if (file != null)
                {


                    using (var fileStream = new FileStream(Path.Combine(hayvanPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                    }
                    hayvan.ResimUrl = @"\img\" + file.FileName;
                }


                if(hayvan.Id == 0)
                {
                    _hayvanRepository.Ekle(hayvan);
                    TempData["basarili"] = "Yeni Hayvan  Başarıyla Oluşturuldu!";
                }
                else
                {
                    _hayvanRepository.Guncelle(hayvan);
                    TempData["basarili"] = "Yeni Hayvan  Başarıyla Güncellendi!";
                }
               
                _hayvanRepository.Kaydet(); // savechamges ile bilgiler veritabanına eklenir.
              
                return RedirectToAction("Index", "Hayvan");
            }
            return View();
        }


        /*
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Hayvan? hayvanVt = _hayvanRepository.Get(u=>u.Id==id);
            if (hayvanVt == null)
            {
                return NotFound();
            }
            return View(hayvanVt);
        }
        

        [HttpPost]
        public IActionResult Guncelle(Hayvan hayvan)
        {




            if (ModelState.IsValid)
            {
                _hayvanRepository.Guncelle(hayvan);
                _hayvanRepository.Kaydet(); // savechamges ile bilgiler veritabanına eklenir.
                TempData["basarili"] = "Yeni Hayvan Başarıyla Güncellendi!";
                return RedirectToAction("Index", "Hayvan");
            }
            return View();
        }
        */

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Hayvan? hayvanVt = _hayvanRepository.Get(u => u.Id == id);
            if (hayvanVt == null)
            {
                return NotFound();
            }
            return View(hayvanVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {

            Hayvan? hayvan = _hayvanRepository.Get(u => u.Id == id);
            if (hayvan == null)
            {
                return NotFound();
            }

            _hayvanRepository.Sil(hayvan);
            _hayvanRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "Hayvan");





        }
    }
}
