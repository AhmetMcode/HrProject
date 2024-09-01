using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface ITasksService : IBaseRepository<Tasks>
    {
        public void Add(Tasks task);
        public void AddTaskLog(TaskLog task);
        public List<Tasks> GetAllInclude();
        public List<TaskLog> GetByLogs(int taskId);
    }
}
