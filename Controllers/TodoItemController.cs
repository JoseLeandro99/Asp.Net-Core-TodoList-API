using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todolistapi.Data;
using todolistapi.Models;

namespace todolistapi.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoItemController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodos(
            [FromServices] DataContext context, [FromQuery] bool done
        )
        {
            var todos = await context.Todos.Where(x => x.Done == done).ToListAsync();
            return todos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<TodoItem>> GetTodoById(
            [FromServices] DataContext context, int id
        )
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(
            [FromServices] DataContext context, [FromBody] TodoItem model
        )
        {
            if (ModelState.IsValid)
            {
                context.Todos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(model);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<TodoItem>> UpdateTodoById(
            [FromServices] DataContext context, [FromQuery] bool done,
            int id
        )
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            todo.Done = done;
            context.Todos.Update(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<string>> DeleteTodoById(
            [FromServices] DataContext context, int id
        )
        {
            var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();

            return "Todo deleted successful";
        }
    }
}