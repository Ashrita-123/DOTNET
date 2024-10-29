using CodeFirstAppWith2Table.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstAppWith2Table.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly TutorialDbContext _context;
        public ArticleRepository(TutorialDbContext context)
        {
            _context = context;
        }
        public Article AddArticle(Article article)
        {
            // throw new NotImplementedException();
            using (var transaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo. [Articles] ON");
                _context.Add(article);
                _context.SaveChanges();
                //_context.Database.ExecuteSqLRaw("SET IDENTITY_INSERT dbo.[Articles] OFF");
                transaction.Commit();
                return article;
            }
        }

        public string DeleteArticle(int id)
        {
            //throw new NotImplementedException();
            if (id > 0)
            {
                Article article = _context.Articles.FirstOrDefault(a => a.ArticleId == id);
                if (article != null)
                {
                    _context.Articles.Remove(article);
                    _context.SaveChanges();
                    return "Article removed";
                }
                else
                {
                    return "Id not Found";
                }
            }
            else
            {
                return "Id is not valid";
            }
        }


        public IEnumerable<Article> GetAllArticle()
        {
            //throw new NotImplementedException();
            var articles = _context.Articles;
            if (articles != null)
                return articles;
            else
                return null;

        }

        public Article GetArticleById(int id)
        {
            //throw new NotImplementedException();
            if (id != 0 || id != null)
            {
                var article = _context.Articles.FirstOrDefault(a => a.ArticleId == id);
                if (article != null)
                    return article;
            }
            return null;
        }

        public IEnumerable<Article> GetArticleByTutorialId(int tutorialId)
        {
            //throw new NotImplementedException();
            return _context.Articles.Where(a => a.TutorialId == tutorialId).ToList();
        }

        public Article UpdateArticle(Article newarticle)
        {
            //throw new NotImplementedException();
            if (newarticle != null)
            {
                var article = _context.Articles.FirstOrDefault(a => a.ArticleId == newarticle.ArticleId);
                if (article != null)
                {
                    article.ArticleTitle = newarticle.ArticleTitle;
                    article.ArticleContent = newarticle.ArticleContent;
                    article.TutorialId = newarticle.TutorialId;
                    _context.Entry(article).State = EntityState.Modified;
                    _context.SaveChanges();
                }
                return newarticle;
            }
            return null;
        }
    }
}

