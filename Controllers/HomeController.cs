using AngeliniMariantonietta.Models;
using AngeliniMariantonietta.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AngeliniMariantonietta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IArticoloService _service;

        public HomeController(ILogger<HomeController> logger, IArticoloService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Article()
        {
            var articoli = _service.GetAllArticles();
            return View(articoli);
        }

        // DETTAGLIO ARTICOLO
        public IActionResult Dettagli(int id)
        {
            var articolo = _service.GetById(id);
            if (articolo == null)
            {
                return NotFound();
            }
            return View(articolo);
        }

        // CANCELLA ARTICOLO
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var articolo = _service.GetById(id);
            _service.Delete(id);

            return RedirectToAction("Article");
        }

        // GET: Crea
        public IActionResult Crea()
        {
            return View();
        }

        // POST: Crea
        [HttpPost]
        public IActionResult Crea(Article article)
        {
                var nuovoArticolo = new Article
                {
                    Nome = article.Nome,
                    Prezzo = article.Prezzo,
                    Descrizione = article.Descrizione,
                    Copertina = article.Copertina,
                    Immagine1 = article.Immagine1,
                    Immagine2 = article.Immagine2,
                };
                _service.Create(nuovoArticolo);
                return RedirectToAction("Article");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
