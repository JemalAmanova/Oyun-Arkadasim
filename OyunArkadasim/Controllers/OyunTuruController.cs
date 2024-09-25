using Microsoft.AspNetCore.Mvc;
using OyunArkadasim.Models;
using OyunArkadasim.Utility;

namespace OyunArkadasim.Controllers
{
    public class OyunTuruController : Controller

    {
        private readonly IOyunTuruRepository _oyunTuruRepository;

        public OyunTuruController(IOyunTuruRepository context)
        {
            _oyunTuruRepository = context;
        }
        public IActionResult Index()
        {
            List<OyunTuru> objOyunTuruList = _oyunTuruRepository.GetAll().ToList();

            return View(objOyunTuruList);
        }
       
    }
}
