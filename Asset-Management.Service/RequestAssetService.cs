using Asset_Management.Repository;
using Asset_Management.ViewModel;

namespace Asset_Management.Service
{
    public class RequestAssetService
    {
        private readonly ApplicationDbContext _context;
        public RequestAssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        // method to convert class
        public RequestAssetModel EntityToModel(RequestAssetEntity entity)
        {
            RequestAssetModel model = new RequestAssetModel();
            model.Id = entity.Id;
            model.PicName = entity.PicName;
            model.PicAddress = entity.PicAddress;
            model.Specification = entity.Specification;
            model.RequestDate = entity.RequestDate;

            return model;
        }
        public RequestAssetDetailResponse EntityToModelDetail(RequestAssetEntity entity)
        {
            RequestAssetDetailResponse response = new RequestAssetDetailResponse();
            response.Id = entity.Id;
            response.PicName = entity.PicName;
            response.PicAddress = entity.PicAddress;
            response.Specification = entity.Specification;
            response.RequestDate = entity.RequestDate;

            var approvals = _context.ApprovalEntities.Where(x => x.RequestAssetId == entity.Id);

            foreach (ApprovalEntity approvalEntity in approvals)
            {
                response.approval.Add(ApprovalEntityToResponse(approvalEntity));
            }


            return response;
        }

        public RequestListResponse EntityToListResponse(RequestAssetEntity entity)
        {
            var list = new RequestListResponse();
            list.Id = entity.Id;
            list.PicName = entity.PicName;
            list.PicAddress = entity.PicAddress;
            list.Specification = entity.Specification;
            list.RequestDate = entity.RequestDate;

            var approvalList = _context.ApprovalEntities.Where(x => x.RequestAssetId == entity.Id).ToList();
            var approval = approvalList.Last();

            list.Status = approval.Status;

            return list;
        }

        public ApprovalResponse ApprovalEntityToResponse(ApprovalEntity entity)
        {
            ApprovalResponse response = new ApprovalResponse();
            response.Id = entity.Id;
            response.Status = entity.Status;
            response.Reason = entity.Reason;
            response.UpdatedDate = entity.Date;

            return response;
        }

        // CRUD + APPROVE/REJECT
        public List<RequestListResponse> GetRequests()
        {
            var result = new List<RequestListResponse>();
            foreach (RequestAssetEntity requestAssetEntity in _context.RequestAssetEntities.ToList())
            {
                result.Add(EntityToListResponse(requestAssetEntity));
            }
            return result;
        }

        public List<RequestAssetModel> GetRequestAssets()
        {
            var result = new List<RequestAssetModel>();
            // nampilin approve ilang
            var list = _context.RequestAssetEntities.Where(x => x.Approval.Count == 1).ToList();
            // foreach (RequestAssetEntity requestAssetEntity in _context.RequestAssetEntities.ToList())
            foreach (RequestAssetEntity requestAssetEntity in list)
            {
                result.Add(EntityToModel(requestAssetEntity));
            }
            return result;
        }

        public List<RequestListResponse> GetRequestList()
        {
            var result = new List<RequestListResponse>();
            foreach (RequestAssetEntity requestAssetEntity in _context.RequestAssetEntities.ToList())
            {
                result.Add(EntityToListResponse(requestAssetEntity));
            }
            return result;
        }

        public void CreateRequestAsset(RequestAssetModel req)
        {
            RequestAssetEntity requestEntity = new RequestAssetEntity();
            requestEntity.Id = req.Id;
            requestEntity.PicName = req.PicName;
            requestEntity.PicAddress = req.PicAddress;
            requestEntity.Specification = req.Specification;
            requestEntity.RequestDate = DateTime.Now;

            //save request asset
            _context.RequestAssetEntities.Add(requestEntity);
            _context.SaveChanges();

            // create approval
            ApprovalEntity approval = new ApprovalEntity();
            approval.RequestAsset = requestEntity;
            approval.RequestAssetId = requestEntity.Id;
            approval.Reason = "";
            approval.Status = "In Process";
            approval.Date = DateTime.Now;

            // save approval to database
            _context.ApprovalEntities.Add(approval);
            _context.SaveChanges();

        }

        public RequestAssetDetailResponse ReadRequestAsset(long? id)
        {
            var request = _context.RequestAssetEntities.Find(id);
            return EntityToModelDetail(request);

        }

        public void ApproveRequest(long? id)
        {
            RequestAssetEntity entity = _context.RequestAssetEntities.Find(id);
            // create approval
            ApprovalEntity approval = new ApprovalEntity();
            approval.RequestAsset = entity;
            approval.RequestAssetId = entity.Id;
            approval.Reason = "";
            approval.Status = "Approved";
            approval.Date = DateTime.Now;
            _context.ApprovalEntities.Add(approval);
            _context.SaveChanges();

            // create pic
            PicEntity picEntity = new PicEntity();
            picEntity.FullName = entity.PicName;
            picEntity.Address = entity.PicAddress;
            _context.PicEntities.Add(picEntity);
            _context.SaveChanges();
        }

        public void SaveRejection(ApprovalReq req)
        {
            var request = _context.RequestAssetEntities.Find(req.Id);
            ApprovalEntity approval = new ApprovalEntity();
            approval.RequestAsset = request;
            approval.RequestAssetId = request.Id;
            approval.Reason = req.Reason;
            approval.Status = "Rejected";
            approval.Date = DateTime.Now;

            _context.ApprovalEntities.Add(approval);
            _context.SaveChanges();
        }
    }
}
