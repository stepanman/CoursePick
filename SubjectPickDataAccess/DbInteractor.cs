using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubjectPickData;

namespace SubjectPickDataAccess
{
    public class DbInteractor : IDbInteractor
    {
        private readonly ApplicationDbContext _context;
        public DbInteractor(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
