using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUygulama1.Models;
using WebUygulama1.Utility;

namespace WebUygulama1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class SahiplenmeController : Controller
    {
        private readonly ISahiplenmeRepository _sahiplenmeRepository;
        private readonly IHayvanRepository _hayvanRepository;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public SahiplenmeController(ISahiplenmeRepository sahiplenmeRepository, IHayvanRepository hayvanRepository, IWebHostEnvironment webHostEnvironment)
        {
            _sahiplenmeRepository = sahiplenmeRepository;
            _hayvanRepository = hayvanRepository;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
           // List<Hayvan> obHayvanList = _hayvanRepository.GetAll().ToList();
            List<Sahiplenme> objSahiplenmeList = _sahiplenmeRepository.GetAll(includeProps:"Hayvan").ToList();




            return View(objSahiplenmeList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> HayvanList = _hayvanRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.HayvanAdi,
                    Value = k.Id.ToString()
                });

            ViewBag.HayvanList = HayvanList;
            if(id == null || id == 0)
            {
                // ekle
                return View();
            }else
            { // guncelle
                Sahiplenme? sahiplenmeVt = _sahiplenmeRepository.Get(u => u.Id == id);
                if (sahiplenmeVt == null)
                {
                    return NotFound();
                }
                return View(sahiplenmeVt);
            }

            
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Sahiplenme sahiplenme)
        {
           



            if (ModelState.IsValid)
            {



                if(sahiplenme.Id == 0)
                {
                    _sahiplenmeRepository.Ekle(sahiplenme);
                    TempData["basarili"] = "Hayvan Sahiplenme işlemi Başarılı!";
                }
                else
                {
                    _sahiplenmeRepository.Guncelle(sahiplenme);
                    TempData["basarili"] = "Hayvan Kayıt güncelleme Başarılı!";
                }
               
                _sahiplenmeRepository.Kaydet(); // savechamges ile bilgiler veritabanına eklenir.
              
                return RedirectToAction("Index", "Sahiplenme");
            }
            return View();
        }


        

        public IActionResult Sil(int? id)
        {

            IEnumerable<SelectListItem> HayvanList = _hayvanRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.HayvanAdi,
                    Value = k.Id.ToString()
                });

            ViewBag.HayvanList = HayvanList;
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Sahiplenme? sahiplenmeVt = _sahiplenmeRepository.Get(u => u.Id == id);
            if (sahiplenmeVt == null)
            {
                return NotFound();
            }
            return View(sahiplenmeVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {

            Sahiplenme? sahiplenme = _sahiplenmeRepository.Get(u => u.Id == id);
            if (sahiplenme == null)
            {
                return NotFound();
            }

            _sahiplenmeRepository.Sil(sahiplenme);
            _sahiplenmeRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı!";
            return RedirectToAction("Index", "Sahiplenme");





        }
    }
}
