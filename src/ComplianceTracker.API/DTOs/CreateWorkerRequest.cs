using System.ComponentModel.DataAnnotations;

namespace ComplianceTracker.API.DTOs;

public class CreateWorkerRequest
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Surname { get; set; } = string.Empty;

    [Required]
    [MaxLength(60)]
    public string JobTitle { get; set; } = string.Empty;

    [Required]
    public Guid SiteId { get; set; }
}