
namespace AngeliniMariantonietta.Services
{
    public class ArticoloService : IArticoloService
    {
        private static readonly List<Article> _articles = new List<Article>();

        public void Delete(int id)
        {
            var articolo = GetById(id);
            if (articolo != null)
            {
                _articles.Remove(articolo);
            }
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articles;
        }

        public Article GetById(int id)
        {
            return _articles.FirstOrDefault(art => art.Id == id);
        }


        public void Create(Article article)
        {
            article.Id = _articles.Count + 1;
            _articles.Add(article);
        }
    }
}
