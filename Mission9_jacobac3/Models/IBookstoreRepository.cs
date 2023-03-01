using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9_jacobac3.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
