using Microsoft.AspNetCore.Mvc;
using PhasecurveBlog.Interfaces;
using PhasecurveBlog.Models;

namespace PhasecurveBlog.Controllers;

public class AuthorController : Controller
{
    private readonly 
        IAuthorRepository _repo;

    public AuthorController(IAuthorRepository repo)
    {
        _repo = repo;
    }

    [HttpPost] 
    public IActionResult AddAuthor(Author author)
    {
        _repo.RegisterAuthor(author);
        _repo.SaveChangesAsync();
        return View();
    } 

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var allRepo = _repo.GetAllAuthors();
        return View(allRepo);
    }
    
    [HttpGet]
    public IActionResult GetAuthor(int id)
    {
        return View(_repo.GetAuthor(id));
    }
    
    [HttpPost]
    public IActionResult UpdateAuthors(int id, string name)
    {
        ViewData["Error"] = "false";
        var author = _repo.GetAuthor(id);
        if (author.Id > 0)
        {
            author.Name = name;
            author.UpdatedOn = DateTime.Now;
            
            _repo.UpdateAuthor(author);
        }
        else
        {
            ViewData["Error"] = "Resource not found";
        }
        return View(_repo.GetAuthor(id));
    }

    [HttpDelete] public IActionResult DeleteArticle(int id)
    {
        _repo.RemoveAuthor(id);
        return View();
    }

    [HttpGet]
    public IActionResult ArticleNotFound(int id)
    {
        return View($"The article with Id: {id} was not found.");
    }
}