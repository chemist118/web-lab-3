using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Models
{
    public class TasksContext : IdentityDbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options)
            : base(options)
        {
        }
        public DbSet<UserTask> Tasks { get; set; }
    }
}