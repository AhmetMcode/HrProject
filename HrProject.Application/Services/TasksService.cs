using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class TasksService : BaseRepository<Tasks>, ITasksService
    {
        public TasksService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public void Add(Tasks task)
        {
            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddTaskLog(TaskLog task)
        {
            try
            {
                _context.TaskLog.Add(task);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Tasks> GetAllInclude()
        {
            return _context.Tasks.Include(x => x.ResponseUser).Include(x => x.OpenUser).Include(x => x.Attachments).ToList();
        }

        public List<TaskLog> GetByLogs(int taskId)
        {

            return _context.TaskLog.Where(x => x.TaskId == taskId).Include(x => x.User).ToList();
        }
    }
}
