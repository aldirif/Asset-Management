using Asset_Management.Repository;

namespace Asset_Management.Service
{
    public class PicService
    {
        private readonly ApplicationDbContext _context;

        public PicService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PicEntity> GetPics() 
        {
            var list = new List<PicEntity>();
            foreach(var item in _context.PicEntities.ToList()) 
            {
                list.Add(item);
            }
            return list;
        }
    }
}
