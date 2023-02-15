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
            Console.WriteLine("aaaaa");
            return  Context.todos.ToList();
        }


        [HttpPost("/post")]
        public TodoModel post([FromBody] TodoModel todo) {
            Context.todos.Add(todo);
            Context.SaveChanges();

            // return todo;

            return todo;
        }

        [HttpPatch("/patch/{id}")]
        public TodoModel post([FromBody] TodoModel todo, [FromRoute] int id) {
            
            
            Context.todos.Entry(todo);
            Context.SaveChanges();

            // return todo;

            return todo;
        }
    }
}