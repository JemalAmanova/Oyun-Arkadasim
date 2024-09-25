using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OyunArkadasim.Models;
 // Ensure the correct namespace is used for repositories
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace OyunArkadasim.Controllers
{
    public class OyunlarimController : Controller
    {
        private readonly IOyunlarimRepository _oyunlarimRepository;
        private readonly IOyunRepository _oyunRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OyunlarimController(IOyunlarimRepository oyunlarimRepository, IOyunRepository oyunRepository, IWebHostEnvironment webHostEnvironment)
        {
            _oyunlarimRepository = oyunlarimRepository;
            _oyunRepository = oyunRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Oyunlarim> objOyunlarimList = _oyunlarimRepository.GetAll(includeProps: "Oyun").ToList();
            return View(objOyunlarimList);
        }

        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> OyunList = _oyunRepository.GetAll()
                .Select(k => new SelectListItem
                {
                    Text = k.OyunAdi,
                    Value = k.Id.ToString()
                });

            ViewBag.OyunList = OyunList;
            if (id == null || id == 0)
            {
                //Ekleme
                return View();
            }
            else
            {
                //Güncelleme:
                Oyunlarim? oyunlarimVt = _oyunlarimRepository.Get(u => u.Id == id);

                if (oyunlarimVt == null)
                {
                    return NotFound();
                }

                return View(oyunlarimVt);
            }
        }

        [HttpPost]
        public IActionResult EkleGuncelle(Oyunlarim oyunlarim)
        {
            if (ModelState.IsValid)
            {
                if (oyunlarim.Id == 0)
                {
                    _oyunlarimRepository.Ekle(oyunlarim);
                }
                else
                {
                    _oyunlarimRepository.Guncelle(oyunlarim);
                }

                _oyunlarimRepository.Kaydet();
                return RedirectToAction("Index", "Oyunlarim");
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Oyunlarim? oyunlarimVt = _oyunlarimRepository.Get(u => u.Id == id);
            if (oyunlarimVt == null)
            {
                return NotFound();
            }
            return View(oyunlarimVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            Oyunlarim? oyunlarim = _oyunlarimRepository.Get(u => u.Id == id);
            if (oyunlarim == null)
            {
                return NotFound();
            }

            _oyunlarimRepository.Sil(oyunlarim);
            _oyunlarimRepository.Kaydet();
            return RedirectToAction("Index", "Oyunlarim");
        }

        [HttpPost]
        public IActionResult Katil(int OyunId)
        {
            // Kullanıcı kimliği veya benzeri bilgileri buradan alabilirsiniz
            var userId = 1; // Bu örnekte sabit bir kullanıcı kimliği kullanıyoruz

            // Oyun bilgilerini al
            var oyun = _oyunRepository.GetOyunById(OyunId);

            if (oyun == null)
            {
                return NotFound();
            }

            // Yeni Oyunlarim nesnesini oluştur ve kaydet
            var yeniOyun = new Oyunlarim
            {
                
                OyunId = OyunId
            };

            _oyunlarimRepository.Ekle(yeniOyun);
            _oyunlarimRepository.Kaydet();

            return RedirectToAction("Index");
        }
    }
}
