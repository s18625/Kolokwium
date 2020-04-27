using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolos.Requests;
using Kolos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        IProjectDal _project;
        IAddTask _addTask;
        public ProjectController(IProjectDal project, IAddTask addTask)
        {
            _project = project;
            _addTask = addTask;
        }

        [HttpGet("{id}")]
        public IActionResult GetProject(int id)
        {
            try
            {
                var result = _project.GetProject(id);
                return Ok(result);
            }catch(Exception e)
            {
                return BadRequest("zle dane \n"+ e.ToString());
            }
            
        }

        [HttpPost]
        public IActionResult AddTasks(TaskTypeRequest task)
        {
            try
            {
                _addTask.AddTask(task);
                return Ok("dodanie powiodlo sie");
            }catch(Exception e)
            {
                return BadRequest("Juz istnieje \n");
            }
            
        }

    }
}