using PhasecurveBlog.Models;

namespace PhasecurveBlog.Data.Repository;

public interface IRepository
{
    void AddArticle(Article article);
    Article GetArticleById(int id);
    List<Article> GetAllArticles();
    Article UpdateArticle(int id);
    string RemoveArticle(int id);
    Task<bool> SaveChangesAsync();


}