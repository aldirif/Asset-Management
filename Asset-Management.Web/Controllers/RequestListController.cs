using Asset_Management.Repository;
using Asset_Management.Service;
using Microsoft.AspNetCore.Mvc;

namespace Asset_Management.Web.Controllers
{
    public class RequestListController : Controller
    {
        private readonly RequestAssetService _service;

        public RequestListController(ApplicationDbContext context)
        {
            _service = new RequestAssetService(context);
        }

        public IActionResult Index()
        {
            var result = _service.GetRequestList();
            return View(result);
        }
    }
}
