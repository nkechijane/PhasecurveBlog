using Microsoft.AspNetCore.Mvc;
using PhasecurveBlog.Interfaces;
using PhasecurveBlog.Models;

namespace PhasecurveBlog.Controllers;

public class ArticleController : Controller
{
    private readonly IArticleRepository _repo;

    public ArticleController(IArticleRepository repo)
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
    public IActionResult ArticleNotFound(int id)
    {
        return View($"The article with Id: {id} was not found.");
    }
    
    [HttpGet]
    public IActionResult GetArticle(int id)
    {
        return View(_repo.GetArticleById(id));
    }

    [HttpGet] 
    public IActionResult AddArticle()
    {
        return View(Index());
    }

    [HttpPost] 
    public IActionResult AddArticle(Article article)
    {
        article.Published = DateTime.Now;
        _repo.AddArticle(article);
        _repo.SaveChangesAsync();
        return View(Index());
    } 

    [HttpGet] 
    public IActionResult UpdateArticle(int id)
    {
        ViewData["Error"] = "false";
        return View(_repo.GetArticleById(id));
    } 
    
    [HttpPost]
    public IActionResult UpdateArticle(int id, string title, string body, string description)
    {
        ViewData["Error"] = "false";
        var article = _repo.GetArticleById(id);
        if (article is not null)
        {
            article.Title = title;
            article.Body = body;
            article.Description = description;
            article.LastEdited = DateTime.Now;
            
            _repo.UpdateArticle(article);
        }
        else
        {
            ViewData["Error"] = "Resource not found";
        }
        _repo.SaveChangesAsync();
        return Redirect("Index");
    }

    [HttpPost] public IActionResult DeleteArticle(int id)
    {
        _repo.RemoveArticle(id);
        _repo.SaveChangesAsync();
        return Redirect("~/Article/Index");
    }
}