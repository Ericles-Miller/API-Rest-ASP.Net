using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Model;

namespace Todo.Controller {

    [ApiController]
    //[Route("home")]
    public class HomeController: ControllerBase {
        
        [HttpGet("/list")]
        public List<TodoModel> get([FromServices] AppDbContext Context) {
            return  Context.todos.ToList();
        }


        [HttpPost("/post")]
        public TodoModel post([FromServices] AppDbContext Context,[FromBody] TodoModel todo) {
            Context.todos.Add(todo);
            Context.SaveChanges();

            return todo;
        }

        [HttpPatch("/patch/{id}")]
        public TodoModel post([FromServices] AppDbContext Context,[FromBody] TodoModel todo, [FromRoute] int id) {
            
            var findId = Context.todos.Where(x => x.id == id).FirstOrDefault();
            findId.done = todo.done;
            Context.todos.Update(findId);
            Context.SaveChanges();

            return findId;
        }
    }
}