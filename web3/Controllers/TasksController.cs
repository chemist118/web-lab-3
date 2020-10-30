using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using web3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace web3.Controllers
{
    public class TasksController : Controller
    {
        private TasksContext _tasksContext;
        
        public TasksController(TasksContext tasksContext)
        {
            _tasksContext = tasksContext;
        }
        
        [Authorize]
        public async Task<UserTask> AddUserTask(string userId, UserTask userTask)
        {
            userTask.UserId = userId;
            await _tasksContext.Tasks.AddAsync(userTask);
            await _tasksContext.SaveChangesAsync();
            return userTask;
        }

        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var userTasks = _tasksContext.Tasks.Where(t => t.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View("Tasks", userTasks);
        }
        [Authorize]
        public async Task<IActionResult> DeleteTask(string userTaskId)
        {
            var userTask = await _tasksContext.Tasks.FindAsync(userTaskId);
            if (userTask.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value)
            {
                _tasksContext.Tasks.Remove(userTask); 
                await _tasksContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(GetAll));
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddTask(UserTask userTask)
        {
            userTask.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await _tasksContext.Tasks.AddAsync(userTask);
            await _tasksContext.SaveChangesAsync();
            return RedirectToAction(nameof(GetAll));
        }
    }
}