using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class App
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "App is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
    public string? Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Version { get; set; }
    public string? RepositoryLink { get; set; }
    
    [ForeignKey(nameof(TechStack))]
    public Guid TechStackId { get; set; }
    public TechStack? Type { get; set; }

    public Guid CreatedBy{ get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
    public Guid DeletedBy { get; set; }
    public DateTime DeletedOn { get; set; }
}