using Asset_Management.Repository;
using Asset_Management.Service;
using Asset_Management.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Management.Web.Controllers
{
    public class AuditController : Controller
    {
        private readonly AuditService _service;

        public AuditController(ApplicationDbContext context)
        {
            _service = new AuditService(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var audit = _service.GetUnvalidatedAudits();
            return View(audit);
        }

        [HttpGet]
        public IActionResult Detail(long? id)
        {
            var audit = _service.ReadAudit(id);
            return View(audit);
        }

        [HttpGet]
        public IActionResult Validated()
        {
            var audit = _service.GetValidatedAudits();
            return View(audit);
        }

        [HttpGet]
        public IActionResult Validate(long? id)
        {
            var audit = _service.ReadAuditReq(id);
            return View(audit);
        }

        [HttpPost]
        public IActionResult UpdateAudit(
            [Bind("Id, AssetHistoryId, Condition, TypeWindows, WindowsLicenseUrl, TypeOffice, OfficeLicenseUrl, Antivirus, AssetPhotoUrl, Result")] AuditValidationReq req)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateAudit(req);
                return Redirect("Index");
            }
            return View("Validate", req);
        }
    }
}
