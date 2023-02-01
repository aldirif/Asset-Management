using Asset_Management.Repository;
using Asset_Management.ViewModel;

namespace Asset_Management.Service
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;

        public AuditService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method
        public AuditResponse EntityToResponse(AuditEntity entity)
        {
            AuditResponse response = new AuditResponse();
            response.Id = entity.Id;
            response.AssetHistoryId = entity.AssetHistoryId;

            var assetHistory = _context.AssetHistoryEntities.Find(entity.AssetHistoryId);
            var asset = _context.AssetEntities.Find(assetHistory.AssetId);
            var pic = _context.PicEntities.Find(assetHistory.PicId);

            response.AssetName = asset.AssetName;
            response.AssetSpecification = asset.Specification;
            response.AssetSerialNumber = asset.SerialNumber;
            response.AssetPurchaseYear = asset.PurchaseYear;

            response.PicName = pic.FullName;
            response.Condition = entity.Condition;
            response.TypeWindows = entity.TypeWindows;
            response.WindowsLicenseUrl = entity.WindowsLicenseUrl;
            response.TypeOffice = entity.TypeOffice;
            response.OfficeLicenseUrl = entity.OfficeLicenseUrl;
            response.Antivirus = entity.Antivirus;
            response.AssetPhotoUrl = entity.AssetPhotoUrl;
            response.Result = entity.Result;

            return response;
        }

        public AuditValidationReq EntityToValidationReq(AuditEntity entity)
        {
            AuditValidationReq request = new AuditValidationReq();
            request.Id = entity.Id;
            request.AssetHistoryId = entity.AssetHistoryId;
            request.Condition = entity.Condition;
            request.TypeWindows = entity.TypeWindows;
            request.WindowsLicenseUrl = entity.WindowsLicenseUrl;
            request.TypeOffice = entity.TypeOffice;
            request.OfficeLicenseUrl = entity.OfficeLicenseUrl;
            request.Antivirus = entity.Antivirus;
            request.AssetPhotoUrl = entity.AssetPhotoUrl;
            request.Result = entity.Result;

            return request;
        }

        public void RequestToEntity(AuditReq request, AuditEntity entity)
        {
            entity.Id = request.Id;
            entity.AssetHistoryId = request.AssetHistoryId;
            entity.Condition = request.Condition;
            entity.TypeWindows = request.TypeWindows;
            entity.WindowsLicenseUrl = request.WindowsLicenseUrl;
            entity.TypeOffice = request.TypeOffice;
            entity.OfficeLicenseUrl = request.OfficeLicenseUrl;
            entity.Antivirus = request.Antivirus;
            entity.AssetPhotoUrl = request.AssetPhotoUrl;
            entity.Result = request.Result;
        }
        public void ValidationReqToEntity(AuditValidationReq request, AuditEntity entity)
        {
            entity.Id = request.Id;
            entity.AssetHistoryId = request.AssetHistoryId;
            entity.Condition = request.Condition;
            entity.TypeWindows = request.TypeWindows;
            entity.WindowsLicenseUrl = request.WindowsLicenseUrl;
            entity.TypeOffice = request.TypeOffice;
            entity.OfficeLicenseUrl = request.OfficeLicenseUrl;
            entity.Antivirus = request.Antivirus;
            entity.AssetPhotoUrl = request.AssetPhotoUrl;
            entity.Result = request.Result;
        }

        // CRUD
        public List<AuditResponse> GetUnvalidatedAudits()
        {
            var listResponse = new List<AuditResponse>();
            var listEntity = _context.AuditEntities.Where(x => x.Result == null).ToList();
            foreach (var entity in listEntity)
            {
                listResponse.Add(EntityToResponse(entity));
            }
            return listResponse;
        }

        public List<AuditResponse> GetValidatedAudits()
        {
            var listResponse = new List<AuditResponse>();
            var listEntity = _context.AuditEntities.Where(x => x.Result != null).ToList();
            foreach (var entity in listEntity)
            {
                listResponse.Add(EntityToResponse(entity));
            }
            return listResponse;
        }

        public void CreateAudit(AuditReq req)
        {
            AuditEntity auditEntity = new AuditEntity();
            RequestToEntity(req, auditEntity);

            auditEntity.AssetHistory = _context.AssetHistoryEntities.Find(req.AssetHistoryId);
            auditEntity.WindowsLicense = req.WindowsLicense;
            auditEntity.OfficeLicense = req.OfficeLicense;
            auditEntity.AssetPhoto = req.AssetPhoto;

            _context.AuditEntities.Add(auditEntity);
            _context.SaveChanges();
        }

        public AuditResponse ReadAudit(long? id)
        {
            var audit = _context.AuditEntities.Find(id);
            return EntityToResponse(audit);
        }

        public AuditValidationReq ReadAuditReq(long? id)
        {
            var audit = _context.AuditEntities.Find(id);
            return EntityToValidationReq(audit);
        }

        public void UpdateAudit(AuditValidationReq req)
        {
            var entity = _context.AuditEntities.Find(req.Id);
            ValidationReqToEntity(req, entity);
            _context.AuditEntities.Update(entity);
            _context.SaveChanges();
        }
    }
}
