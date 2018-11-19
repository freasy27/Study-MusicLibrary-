using Music.Data.Model;
using System.Collections.Generic;

namespace Music.ViewModel
{
    public class LendViewModel
    {
        public Data.Model.Music Music { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
