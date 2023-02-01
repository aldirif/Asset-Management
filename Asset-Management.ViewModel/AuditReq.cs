using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Asset_Management.ViewModel
{
    public class AuditReq
    {
        public long Id { get; set; }
        public long AssetHistoryId { get; set; }
        public string Condition { get; set; }
        public string TypeWindows { get; set; }
        public string? WindowsLicenseUrl { get; set; }

        [Required(ErrorMessage = "Screenshot of Windows License have not been uploaded yet")]
        [Display(Name = "WindowsLicense")]
        public IFormFile? WindowsLicense { get; set; }

        public string TypeOffice { get; set; }
        public string? OfficeLicenseUrl { get; set; }

        [Required(ErrorMessage = "Screenshot of Office License have not been uploaded yet")]
        [Display(Name = "OfficeLicense")]
        public IFormFile? OfficeLicense { get; set; }

        public bool Antivirus { get; set; }

        public string? AssetPhotoUrl { get; set; }

        [Required(ErrorMessage = "Photo of Asset have not been uploaded yet")]
        [Display(Name = "AssetPhoto")]
        public IFormFile? AssetPhoto { get; set; }

        public string? Result { get; set; }
    }
}
