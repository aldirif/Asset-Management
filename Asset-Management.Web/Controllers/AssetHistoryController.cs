using Asset_Management.Repository;
using Asset_Management.Service;
using Asset_Management.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asset_Management.Web.Controllers
{
    public class AssetHistoryController : Controller
    {
        private readonly AssetHistoryService _assetHistoryService;
        private readonly AssetService _assetService;
        private readonly PicService _picService;

        public AssetHistoryController(ApplicationDbContext context)
        {
            _assetHistoryService = new AssetHistoryService(context);
            _assetService = new AssetService(context);
            _picService = new PicService(context);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _assetHistoryService.GetAssetHistory();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Asset = new SelectList(_assetService.GetAssets(), "Id", "AssetNameWithSnSpec");
            ViewBag.Pic = new SelectList(_picService.GetPics(), "Id", "FullName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Asset = new SelectList(_assetService.GetAssets(), "Id", "AssetNameWithSnSpec");
            ViewBag.Pic = new SelectList(_picService.GetPics(), "Id", "FullName");
            return PartialView("_Add");
        }

        [HttpPost]
        public IActionResult Save([Bind("AssetId, Location, PicId,SendDate")] AssetHistoryReq req)
        {
            if (ModelState.IsValid)
            {
                _assetHistoryService.CreateAssetHistory(req);
                return Redirect("Index");
            }
            return View("Add", req);
        }


    }
}
