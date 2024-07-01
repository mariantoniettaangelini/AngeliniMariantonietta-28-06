using System.ComponentModel.DataAnnotations;

namespace AngeliniMariantonietta
{
    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "È obbligatorio inserire il nome dell'articolo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "È obbligatorio inserire il prezzo dell'articolo")]
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public IFormFile Copertina { get; set; }
        public IFormFile Immagine1 { get; set; }
        public IFormFile Immagine2 { get; set; }
    }
}
