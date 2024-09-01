using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Models;
using System.Security.Claims;

namespace HrProject.Presentation.Controllers
{
    public class KanbanController : Controller
    {
        private readonly ITasksService tasksService;
        private readonly INotificationService notificationService;

        public KanbanController(ITasksService tasksService, INotificationService notificationService)
        {
            this.tasksService = tasksService;
            this.notificationService = notificationService;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Roller.Role_Admin);
            var tasks = tasksService.GetAllInclude();


            if (isAdmin)
            {
                tasks = tasksService.GetAllInclude().ToList();
            }
            else
            {
                tasks = tasksService.GetAllInclude().Where(t => t.OpenUserId == userId).ToList();
            }

            return View(tasks);
        }
        [HttpPost]
        public IActionResult AddTask([FromBody] Tasks taskData)
        {
            taskData.CreatedTime = DateTime.Now;
            string userId2 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            taskData.OpenUserId = userId2;
            taskData.ResponseUserId = userId2;
            taskData.Status = Status.None;
            tasksService.Add(taskData);

            return Json("");
        }
        [HttpGet]
        public IActionResult DeleteTask(int taskId)
        {
            string userId2 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = tasksService.GetById(taskId);
            if (task.Status != Status.None)
            {
                return Json("Üzerine İşlem Yapılmış Kart Silinemez");
            }
            else
            {
                TaskLog taskLog = new TaskLog();
                taskLog.TaskId = taskId;
                taskLog.UserId = userId2;
                taskLog.FromStatus = Status.None;
                taskLog.ToStatus = Status.Delete;
                tasksService.Delete(taskId);
                return Json("ok");
            }
        }
        [HttpPost]
        public IActionResult SetStatus(int id, Status status)
        {
            string userId2 = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var task = tasksService.GetById(id);
            notificationService.SendNotification(userId2, "Taskınız Güncellendi", "Task Durumu Güncellendi", task.OpenUserId, "Blue");
            if (task.Status != status)
            {
                TaskLog taskLog = new TaskLog();
                taskLog.TaskId = id;
                taskLog.CreatedTime = DateTime.Now;
                taskLog.FromStatus = task.Status;
                taskLog.ToStatus = status;
                taskLog.UserId = userId2;
                tasksService.AddTaskLog(taskLog);
                task.Status = status;
                tasksService.Update(task);

                return Json("ok");
            }
            else
            {
                return Json("işlem sırasında hata");
            }
        }
        [HttpGet]
        public IActionResult KanbanMessagePartial(int id)
        {
            var taskLogs = tasksService.GetByLogs(id);
            return PartialView(taskLogs);
        }
    }
}
