using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Framework
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Framework is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the is 60 characters.")]
    public string? Name { get; set; }
    
    public Guid CreatedBy{ get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }
}