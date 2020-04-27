using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolos.Models
{
    public class Task
    {
        public int IdTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int IdProject { get; set; }
        public int IdTaskType { get; set; }
        public int IdAssignedTo { get; set; }
        public int IdCreator { get; set; }

    }
}
