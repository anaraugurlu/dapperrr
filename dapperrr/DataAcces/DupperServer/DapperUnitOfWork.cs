using dapperrr.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapperrr.DataAcces.DupperServer
{
    
    public class DapperUnitOfWork : IUnitOfWork
    {
     

        public IBookRepository BookRepository => new DapperBookRepository();
    }
}
