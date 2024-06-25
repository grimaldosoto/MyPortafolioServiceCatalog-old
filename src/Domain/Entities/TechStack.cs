using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class TechStack
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name of TechStack is a required filed.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is a 60 characters.")]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Details { get; set; }
    
    public Guid CreatedBy{ get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }
}