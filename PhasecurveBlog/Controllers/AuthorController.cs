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

    public IActionResult AddAuthor()
    {
        return View();
    } 

    [HttpPost] 
    public IActionResult AddAuthor(Author author)
    {
        _repo.RegisterAuthor(author);
        _repo.SaveChangesAsync();
        return Redirect("../Home/Index");
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
    
    public IActionResult UpdateAuthor(int id)
    {
        ViewData["Error"] = "false";
        var author = _repo.GetAuthor(id);
        if (author.Id > 0)
        {
            return View(author);
        }
        else
        {
            ViewData["Error"] = "Resource not found";
            return View(author);
        }
    }
    
    [HttpPost]
    public IActionResult UpdateAuthor(int id, string name)
    {
        ViewData["Error"] = "false";
        var author = _repo.GetAuthor(id);
        if (author.Id > 0)
        {
            author.Name = name;
            author.UpdatedOn = DateTime.Now;
            
            _repo.UpdateAuthor(author);
            _repo.SaveChangesAsync();
        }
        else
        {
            ViewData["Error"] = "Resource not found";
        }
        return View(_repo.GetAuthor(id));
    }
    
    [HttpPost]
    public IActionResult DeleteAuthor(int id)
    {
        _repo.RemoveAuthor(id);
        _repo.SaveChangesAsync();
        return Redirect("GetAllAuthors");
    }
}