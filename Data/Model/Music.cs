using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Data.Model
{
    public class Music
    {
        public int MusicID { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Title { get; set; }
        public virtual Author Author { get; set; }
        public int AuthorID { get; set; }
        public virtual Customer Borrower { get; set; }
        public int BorrowerID { get; set; }
    }
}
