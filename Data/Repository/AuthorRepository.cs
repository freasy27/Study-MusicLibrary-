using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Data.Interfaces;
using Music.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Music.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {
        }

        public IEnumerable<Author> GetAllWithMusics()
        {
            return _context.Authors.Include(a => a.Musics);
        }


        public Author GetWithMusics(int id)
        {
            return _context.Authors
                .Where(a => a.AuthorID == id)
                .Include(a => a.Musics)
                .FirstOrDefault();
        }
    }
}
