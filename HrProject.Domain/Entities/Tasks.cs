using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public enum Urgency
    {
        Low,
        Medium,
        High
    }

    public enum Status
    {
        None,
        Todo,
        InProgress,
        Done,
        Delete
    }

    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public Tasks Tasks { get; set; }
        public int TasksId { get; set; }
    }

    // Entity for storing Kanban tasks
    public class Tasks : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string? DetayliAciklama { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; } // Nullable, as the task may not be completed
        public Urgency Urgency { get; set; }
        public Status Status { get; set; }
        public string OpenUserId { get; set; } // Foreign key for assigned user
        public ApplicationUser OpenUser { get; set; } // Navigation property for user
        public string ResponseUserId { get; set; } // Foreign key for assigned user
        public ApplicationUser ResponseUser { get; set; } // Navigation property for user
        public List<Attachment> Attachments { get; set; } // List of attachments
    }
    public class TaskLog : BaseEntity
    {
        public int TaskId { get; set; } // Hangi görev üzerinde yapıldığı
        public Tasks Task { get; set; } // Göreve erişim sağlar
        public string UserId { get; set; } // Hangi kullanıcı tarafından yapıldığı
        public ApplicationUser User { get; set; } // Kullanıcıya erişim sağlar
        public DateTime DateTime { get; set; } // Ne zaman yapıldığı
        public Status FromStatus { get; set; } // Önceki durumu
        public Status ToStatus { get; set; } // Yeni durumu
    }
    public class TaskMessage : BaseEntity
    {
        public int TaskId { get; set; } // Hangi görevle ilişkili olduğu
        public Tasks Task { get; set; } // Göreve erişim sağlar
        public string UserId { get; set; } // Mesajı gönderen kullanıcı
        public ApplicationUser User { get; set; } // Kullanıcıya erişim sağlar
        public string Message { get; set; } // Mesaj içeriği
        public DateTime DateTime { get; set; } // Mesajın gönderildiği tarih
    }

}
