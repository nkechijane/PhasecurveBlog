using PhasecurveBlog.Models;

namespace PhasecurveBlog.Data.Repository;

public class ArticleRepository : IRepository
{
    private readonly ApplicationDbContext _context;
    
    public ArticleRepository(ApplicationDbContext context)
    {
        _context = context;
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

    public async Task<bool> SaveChangesAsync()
    {
        if (await _context.SaveChangesAsync() > 0)
        {
            return true;
        }

        return false;
    }
}