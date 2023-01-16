using PhasecurveBlog.Interfaces;
using PhasecurveBlog.Models;

namespace PhasecurveBlog.Data.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public void RegisterAuthor(Author author)
    {
        _context.Authors.Add(author);
    }
    public Author GetAuthor(int id)
    {
        return _context.Authors.FirstOrDefault(a => a.Id == id);
    }

    public List<Author> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }

    public void RemoveAuthor(int id)
    {
        _context.Authors.FirstOrDefault(GetAuthor(id));
    }

    public void UpdateAuthor(Author author)
    { 
        _context.Authors.Update(author);
    }
}