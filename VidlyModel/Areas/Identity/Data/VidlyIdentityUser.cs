using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VidlyModel.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VidlyModelUser class
public class VidlyIdentityUser : IdentityUser<int>
{
    public string? DrivingLicense { get; set; }

}


