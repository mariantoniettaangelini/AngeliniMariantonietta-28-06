namespace AngeliniMariantonietta.Services
{
    public interface IArticoloService
    {
        IEnumerable<Article> GetAllArticles();
        Article GetById (int id);
        void Create(Article article);
        void Delete (int id);
    }
}
