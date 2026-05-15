using Microsoft.AspNetCore.Identity;

namespace HospitalManagementSystem.Infrastructure;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}

