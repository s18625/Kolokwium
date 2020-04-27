using Kolos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Services
{
    public interface IAddTask
    {
        public void AddTask(TaskTypeRequest taskR);
    }
}
