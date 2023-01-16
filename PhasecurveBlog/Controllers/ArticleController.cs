using Microsoft.AspNetCore.Mvc;
using PhasecurveBlog.Data.Repository;
using PhasecurveBlog.Models;

namespace PhasecurveBlog.Controllers;

public class ArticleController : Controller
{
    private readonly IRepository _repo;

    public ArticleController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var allRepo = _repo.GetAllArticles();
        return View(allRepo);
    }
    
    [HttpGet]
    public IActionResult GetArticle(int id)
    {
        return View(_repo.GetArticleById(id));
    }

    [HttpPost] public IActionResult AddArticle(Article article)
    {
        _repo.AddArticle(article);
        return View(Index());
    } 
    
    [HttpPost] public IActionResult UpdateArticle(int id, string title, string body)
    {
        var article = _repo.GetArticleById(id);
        if (article.Id > 0)
        {
            article.Title = title;
            article.Body = body;
            article.LastEdited = DateTime.Now;
            
            _repo.UpdateArticle(article);
        }
        return View(Index());
    } 
    
    [HttpDelete] public IActionResult DeleteArticle(int id)
    {
        _repo.RemoveArticle(id);
        return View(Index());
    }
}