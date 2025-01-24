using Adeela.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adeela.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodoItemsAsync(string userId);
        Task AddTodoItemAsync(TodoItem item);
        Task ToggleTodoItemCompletionAsync(int id);
        Task DeleteTodoItemAsync(int id);
        Task UpdateTodoItemAsync(TodoItem item);
    }
}



