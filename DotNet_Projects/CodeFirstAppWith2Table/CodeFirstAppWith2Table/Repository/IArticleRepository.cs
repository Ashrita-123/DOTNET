using CodeFirstAppWith2Table.Models;

namespace CodeFirstAppWith2Table.Repository
{
    public interface IArticleRepository
    {
        Article AddArticle(Article article);
        Article UpdateArticle(Article article);
        string DeleteArticle(int id);
        Article GetArticleById(int id);
        IEnumerable<Article> GetAllArticle();
        IEnumerable<Article> GetArticleByTutorialId(int tutorialId);
       // string? GetArticleById(int id);
    }
}
