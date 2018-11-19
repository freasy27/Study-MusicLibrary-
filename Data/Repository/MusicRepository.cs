using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Music.Data.Interfaces;
using Music.Data.Model;

namespace Music.Data.Repository
{
    public class MusicRepository : Repository<Model.Music>, IMusicRepository
    {
        public MusicRepository(LibraryDbContext context) : base(context)
        {

        }
        public IEnumerable<Model.Music> FindWithAuthor(Func<Model.Music, bool> predicate)
        {
            return _context.Musics
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Model.Music> FindWithAuthorAndBorrower(Func<Model.Music, bool> predicate)
        {
            return _context.Musics
                .Include(a => a.Author)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IEnumerable<Model.Music> GetAllWithAuthor()
        {
            return _context.Musics.Include(a => a.Author);
        }
    }
}
