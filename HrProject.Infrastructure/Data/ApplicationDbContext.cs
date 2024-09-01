using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;

namespace HrProject.Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       
        public DbSet<WareHouse> WareHouses { get; set; }
       
        public DbSet<Person> Personals { get; set; }
        public DbSet<PersonPosition> PersonPosition { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<PersonSalary> PersonSalaries { get; set; }
       
        public DbSet<PersonAdvancePayment> PersonAdvancePayments { get; set; }
        public DbSet<PersonPermissionPayment> PersonPermissionPayments { get; set; }
        public DbSet<PersonPermissionTransfer> PersonPermissionTransfer { get; set; }
        public DbSet<PersonPermissionRule> PersonPermissionRules { get; set; }
        public DbSet<PersonAnnualLeave> PersonAnnualLeaves { get; set; }
        public DbSet<PersonPermissionType> PersonPermissionTypes { get; set; }
        public DbSet<PersonPermission> PersonPermissions { get; set; }
       
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationDetail> NotificationDetails { get; set; }
        
        public DbSet<TallyDetail> TallyDetail { get; set; }
        public DbSet<Account2> Accounts2 { get; set; }
       
        public DbSet<PersonMounthPayment> PersonMounthPayments { get; set; }
       
        public DbSet<PersonelAuthority> PersonelAuthorities { get; set; }
        public DbSet<PersonelDocument> PersonelDocuments { get; set; }
        public DbSet<PersonelInterDoc> PersonelInterDocs { get; set; }
     
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<TaskLog> TaskLog { get; set; }
        public DbSet<TaskMessage> TaskMessage { get; set; }
      
        public DbSet<LogKayit> LogKayits { get; set; }
        public DbSet<UserEmail> UserEmail { get; set; }
       
        public DbSet<MessageModule> MessageModule { get; set; }
        public DbSet<PersonIstenCikar> PersonIstenCikar { get; set; }

    }
}