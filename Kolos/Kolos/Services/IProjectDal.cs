using Kolos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Services
{
    public interface IProjectDal
    {
        public IEnumerable<Project> GetProject(int id);
    }
}
