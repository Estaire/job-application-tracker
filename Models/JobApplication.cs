using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JobTracker.Web.Models;

public class JobApplication
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Company")]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Role")]
    public string RoleTitle { get; set; } = string.Empty;

    [Display(Name = "Status")]
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Saved;

    [Display(Name = "Date Applied")]
    public DateTime DateApplied { get; set; } = DateTime.UtcNow;

    [Display(Name = "Job Posting URL")]
    public string? JobPostingUrl { get; set; }

    [Display(Name = "Notes")]
    public string? Notes { get; set; }

    public string UserId { get; set; } = string.Empty;

    public IdentityUser? User { get; set; }
}