using System.Collections.Generic;
using Music.Data.Model;

namespace Music.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithMusics();
        Author GetWithMusics(int id);
    }
}
