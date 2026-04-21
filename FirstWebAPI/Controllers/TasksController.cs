using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/<TasksController>
        [HttpGet]

        public IEnumerable<Repository.Models.Task> Get()
        {
            try
            {
                using PesachTasksDbContext ctx = new();
                return ctx.Tasks.ToList();
            }
            catch
            {
                //todo: לבדוק מה הכי נכון להחזיר
                throw new Exception("שגיאה בגישה למסד הנתונים");
            }   

             
        }



        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }



        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
