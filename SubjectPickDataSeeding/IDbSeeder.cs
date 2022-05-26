using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePickDataSeeding
{
    public interface IDbSeeder
    {
        Task Seed();
    }
}
