using Music.Data.Model;
using System;
using Music.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.ViewModel
{
    public class MusicViewModel
    {
        public Data.Model.Music Music { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
