using System;
using System.Collections.Generic;

namespace Music.Data.Interfaces
{
    public interface IMusicRepository : IRepository<Model.Music>
    {
        IEnumerable<Model.Music> GetAllWithAuthor();
        IEnumerable<Model.Music> FindWithAuthor(Func<Model.Music, bool> predicate);
        IEnumerable<Model.Music> FindWithAuthorAndBorrower(Func<Model.Music, bool> predicate);
    }
}
