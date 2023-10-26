
namespace Automation.Infrastructure.Data;

public class AutomationDbContext : IdentityDbContext
{
    public AutomationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
    public DbSet<Mail> Mails { get; set; }
    public DbSet<MailAttachment> MailAttachments { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
}
