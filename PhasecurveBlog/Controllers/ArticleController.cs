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
        return View(_repo.GetAllArticles());
    }
    
    [HttpGet]
    public IActionResult Article(int id)
    {
        return View(_repo.GetArticleById(id));
    }
}