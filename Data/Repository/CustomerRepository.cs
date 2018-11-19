using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Music.Data.Interfaces;
using Music.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Music.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base (context)
        {

        }
    }
}
