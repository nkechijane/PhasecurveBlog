using PhasecurveBlog.Models;

namespace PhasecurveBlog.Interfaces;

public interface IAuthorRepository
{
    void RegisterAuthor(Author author);
    void RemoveAuthor(int id);
    void UpdateAuthor(Author author);
    Author GetAuthor(int id);
    List<Author> GetAllAuthors();
}