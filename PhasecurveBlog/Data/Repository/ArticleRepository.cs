using PhasecurveBlog.Models;

namespace PhasecurveBlog.Data.Repository;

public class ArticleRepository : IRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
        var id = 1;
        if (!_context.Articles.Any(a => a.Id == id))
        {
            _context.Articles.Add(
                new Article
                {
                    Body = "In fact, one major benefit to not being all the buzz is that “the buzz” has evolved far enough in the last several years that many modern patterns can be applied to more traditional means of building websites and applications.",
                    Description = "This is a dummy article for display purposes",
                    Title = "Test",
                    Id = id,
                    LastEdited =DateTime.Now,
                    Published = DateTime.Now,
                    Images = string.Empty
                });
            _context.SaveChanges();
            
        }
    }
    
    public void AddArticle(Article article)
    {
        _context.Articles.Add(article);
    }

    public Article GetArticleById(int id)
    {
        return _context.Articles.FirstOrDefault(a => a.Id == id);
    }

    public List<Article> GetAllArticles()
    {
        return _context.Articles.ToList();
    }

    public void UpdateArticle(Article article)
    {
        _context.Articles.Update(article);
    }

    public void RemoveArticle(int id)
    {
        _context.Articles.Remove(GetArticleById(id));
    }

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}