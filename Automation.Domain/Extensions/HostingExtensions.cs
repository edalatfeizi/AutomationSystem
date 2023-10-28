
namespace Automation.Domain.Extensions;

public static class HostingExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IMailAttachmentService, MailAttachmentService>();

        return services;
    }
}
