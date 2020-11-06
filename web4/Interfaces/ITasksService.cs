using System.Collections.Generic;
using System.Threading.Tasks;
using web4.Data.Api;
using web4.Data.Entities;

namespace web4.Interfaces
{
    public interface ITasksService
    {
        Task<UserTask> GetUserTask(string userId, string userTaskId);
        Task<IEnumerable<UserTask>> GetUserTasks(string userId);
        Task<UserTask> AddUserTask(string userId, UserTask userTask);
        Task<bool> DeleteUserTask(string userId, string userTaskId);
        Task<bool> ToggleCompleteTask(string userId, string userTaskId);
        Task<IEnumerable<string>> GetCommentsUserTask(string userId, string userTaskId);
    }
}