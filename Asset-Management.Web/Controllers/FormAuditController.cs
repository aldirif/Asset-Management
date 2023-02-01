using Asset_Management.Repository;
using Asset_Management.Service;
using Asset_Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asset_Management.Web.Controllers
{
    public class FormAuditController : Controller
    {
        private readonly AuditService _auditService;
        private readonly AssetHistoryService _assetHistoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FormAuditController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _auditService = new AuditService(context);
            _assetHistoryService = new AssetHistoryService(context);
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "upload_audit");
                string fileType = file.FileName.Split('.').Last();
                uniqueFileName = Guid.NewGuid().ToString() + "." + fileType; ;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.AssetHistory = new SelectList(_assetHistoryService.GetAssetHistory(), "Id", "PicName");
            return View();
        }
        [HttpPost]
        public IActionResult Save(
            [Bind("AssetHistoryId, Condition, TypeWindows, WindowsLicense, TypeOffice, OfficeLicense, Antivirus, AssetPhoto")] AuditReq req)
        {
            if (ModelState.IsValid)
            {
                req.WindowsLicenseUrl = UploadedFile(req.WindowsLicense);
                req.OfficeLicenseUrl = UploadedFile(req.OfficeLicense);
                req.AssetPhotoUrl = UploadedFile(req.AssetPhoto);
                _auditService.CreateAudit(req);

                return Redirect("/FormAudit/Success");
            }
            return View("Index", req);
        }
        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }

    }
}
