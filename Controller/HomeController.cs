using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Model;

namespace Todo.Controller {

    [ApiController]
    //[Route("home")]
    public class HomeController: ControllerBase {
        private readonly AppDbContext Context;

        public HomeController(AppDbContext context)
        {
            Context = context;   
        }
        [HttpGet("/list")]
        public List<TodoModel> get() {
            return  Context.todos.ToList();
        }


        [HttpPost("/post")]
        public TodoModel post([FromBody] TodoModel todo) {
            Context.todos.Add(todo);
            Context.SaveChanges();

            return todo;
        }

        [HttpPatch("/patch/{id}")]
        public TodoModel post([FromBody] TodoModel todo, [FromRoute] int id) {
            
            var findId = Context.todos.Where(x => x.id == id).FirstOrDefault();
            findId.done = todo.done;
            Context.todos.Update(findId);
            Context.SaveChanges();

            return findId;
        }
    }
}