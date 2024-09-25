    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using OyunArkadasim.Controllers;
    using OyunArkadasim.Models;
    using OyunArkadasim.Utility;

    namespace OyunArkadasim.Controllers
    {
        public class OyunController : Controller
        {
            private readonly IOyunRepository _oyunRepository;
            private readonly IOyunTuruRepository _oyunTuruRepository;
            public readonly IWebHostEnvironment _webHostEnvironment;
            public OyunController(IOyunRepository oyunRepository, IOyunTuruRepository oyunTuruRepository, IWebHostEnvironment webHostEnvironment)
            {
                _oyunRepository = oyunRepository;
                _oyunTuruRepository = oyunTuruRepository;
                _webHostEnvironment = webHostEnvironment;
            }
            public IActionResult Index()
            {
                // List<Oyun> objOyunList = _oyunRepository.GetAll().ToList();
                List<Oyun> objOyunList = _oyunRepository.GetAll(includeProps: "OyunTuru").ToList();

                return View(objOyunList);
            }


            public IActionResult EkleGuncelle(int? id)
            {
                IEnumerable<SelectListItem> OyunTururList = _oyunTuruRepository.GetAll()
                    .Select(k => new SelectListItem
                    {
                        Text = k.OyunTuruAdi,
                        Value = k.TurId.ToString()
                    });

                ViewBag.OyunTuruList = OyunTururList;
                if (id == null || id == 0)
                {
                    //Ekleme
                    return View();
                }
                else
                {
                    //Güncelleme:
                    Oyun? oyunVt = _oyunRepository.Get(u => u.Id == id);

                    if (oyunVt == null)
                    {
                        return NotFound();
                    }

                    return View(oyunVt);

                }
            }

        [HttpPost]
        public IActionResult EkleGuncelle(Oyun oyun, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string oyunPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {

                    using (var fileStream = new FileStream(Path.Combine(oyunPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    oyun.ResimUrl = @"/img/" + file.FileName;
                }

                if (oyun.Id == 0)
                 {
                        _oyunRepository.Ekle(oyun);

                 }
                else
                {
                        _oyunRepository.Guncelle(oyun);

                }

                    _oyunRepository.Kaydet();
                    return RedirectToAction("Index", "Oyun");
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

                    Oyun oyun = _oyunRepository.Get(u => u.Id == id);

                    if (oyun == null)
                    {
                        return NotFound();
                    }

                    return View(oyun);
                }
        */

        /*

        [HttpPost]
        public IActionResult Guncelle(Oyun oyun)
        {
            if (ModelState.IsValid)
            {
                _oyunRepository.Guncelle(oyun);
                _oyunRepository.Kaydet();
                return RedirectToAction("Index", "Oyun");
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
                    Oyun? oyunVt = _oyunRepository.Get(u => u.Id == id);
                    if (oyunVt == null)
                    {
                        return NotFound();
                    }
                    return View(oyunVt);
                }

                [HttpPost, ActionName("Sil")]

            public IActionResult SilPOST(int? id)
                {
                    Oyun? oyun = _oyunRepository.Get(u => u.Id == id);
                    if (oyun == null)
                    {
                        return NotFound();
                    }

                    _oyunRepository.Sil(oyun);
                    _oyunRepository.Kaydet();
                    return RedirectToAction("Index", "Oyun");


                }


        }
    }
    



