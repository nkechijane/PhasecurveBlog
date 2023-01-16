using PhasecurveBlog.Models;

namespace PhasecurveBlog.Data.Repository;

public interface IRepository
{
    void AddArticle(Article article);
    Article GetArticleById(int id);
    List<Article> GetAllArticles();
    void UpdateArticle(Article article);
    void RemoveArticle(int id);
    Task<bool> SaveChangesAsync();
}