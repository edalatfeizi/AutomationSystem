
using System.ComponentModel.DataAnnotations.Schema;

namespace Automation.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    [ForeignKey("Parent")]
    public Guid? ParentId { get; set; }
    public Department? Parent { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}
