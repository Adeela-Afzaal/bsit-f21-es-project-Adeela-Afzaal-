using Microsoft.EntityFrameworkCore;
using Adeela.Data;
namespace Adeela.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _context;

        public TodoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetTodoItemsAsync(string userId)
        {
            return await _context.TodoItems
                .Where(item => item.UserId == userId)
                .ToListAsync();
        }

        public async Task AddTodoItemAsync(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task ToggleTodoItemCompletionAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                item.IsComplete = !item.IsComplete;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateTodoItemAsync(TodoItem item)
        {
            var existingItem = await _context.TodoItems.FirstOrDefaultAsync(t => t.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsComplete = item.IsComplete;
                existingItem.Description = item.Description; // Update description
                existingItem.ImagePath = item.ImagePath; // Update image path
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTodoItemAsync(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item != null)
            {
                _context.TodoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }

}



