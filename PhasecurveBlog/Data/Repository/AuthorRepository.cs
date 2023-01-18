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
        author.RegisteredTime = DateTime.Now;
        _context.Authors.Add(author);
    }
    public Author GetAuthor(int id)
    {
        var response = _context.Authors.FirstOrDefault(a => a.Id == id);
        return response ?? new Author();
    }

    public List<Author> GetAllAuthors()
    {
        return _context.Authors.ToList();
    }

    public void RemoveAuthor(int id)
    {
        _context.Authors.Remove(GetAuthor(id));
    }

    public void UpdateAuthor(Author author)
    { 
        author.UpdatedOn = DateTime.Now;
        _context.Authors.Update(author);
    }
    
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}