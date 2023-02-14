using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Model;

namespace Todo.Controller {

    [ApiController]
    [Route("home")]
    public class HomeController: ControllerBase {
        [HttpGet("/")]
        
        public List<TodoModel> get([FromServices] AppDbContext context) {
            return  context.todos.ToList();
        }
    }
}