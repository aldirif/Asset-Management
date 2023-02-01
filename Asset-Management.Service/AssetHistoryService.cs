using Asset_Management.Repository;
using Asset_Management.ViewModel;

namespace Asset_Management.Service
{
    public class AssetHistoryService
    {
        private readonly ApplicationDbContext _context;
        //context = database
        public AssetHistoryService(ApplicationDbContext context)
        {
            _context = context;

        }
        public AssetHistoryResponse EntityToResponse(AssetHistoryEntity entity)
        {
            var response = new AssetHistoryResponse();

            response.Id = entity.Id;
            response.AssetId = entity.AssetId;
            response.Location = entity.Location;
            response.PicId = entity.PicId;
            response.SendDate = entity.SendDate;

            var asset = _context.AssetEntities.Find(entity.AssetId);
            response.AssetName = asset.AssetName;
            response.Specification = asset.Specification;
            response.PurchaseYear = asset.PurchaseYear;
            response.SerialNumber = asset.SerialNumber;

            var pic = _context.PicEntities.Find(entity.PicId);
            response.PicName = pic.FullName;

            return response;
        }
        //crud
        public void CreateAssetHistory(AssetHistoryReq req)
        {
            var entity = new AssetHistoryEntity();
            entity.Id = req.Id;
            entity.AssetId = req.AssetId;
            entity.Location = req.Location;
            entity.PicId = req.PicId;
            entity.SendDate = req.SendDate;

            var asset = _context.AssetEntities.Find(req.AssetId);
            entity.Asset = asset;

            var pic = _context.PicEntities.Find(req.PicId);
            entity.Pic = pic;

            _context.AssetHistoryEntities.Add(entity);
            _context.SaveChanges();
        }

        public List<AssetHistoryResponse> GetAssetHistory()
        {
            var list = new List<AssetHistoryResponse>();
            foreach (var item in _context.AssetHistoryEntities.ToList())
            {
                list.Add(EntityToResponse(item));
            }
            return list;
        }








    }
}
