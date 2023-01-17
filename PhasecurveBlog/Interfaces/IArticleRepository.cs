using PhasecurveBlog.Models;

namespace PhasecurveBlog.Interfaces;

public interface IArticleRepository
{
    void AddArticle(Article article);
    Article? GetArticleById(int id);
    List<Article> GetAllArticles();
    void UpdateArticle(Article article);
    void RemoveArticle(int id);
    Task<bool> SaveChangesAsync();
}