using Microsoft.EntityFrameworkCore;

namespace Asset_Management.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<AccountEntity> AccountEntities => Set<AccountEntity>();
        public DbSet<PicEntity> PicEntities => Set<PicEntity>();
        public DbSet<AssetEntity> AssetEntities => Set<AssetEntity>();
        public DbSet<ApprovalEntity> ApprovalEntities => Set<ApprovalEntity>();
        public DbSet<RequestAssetEntity> RequestAssetEntities => Set<RequestAssetEntity>();
        public DbSet<AssetHistoryEntity> AssetHistoryEntities => Set<AssetHistoryEntity>();
        public DbSet<AuditEntity> AuditEntities => Set<AuditEntity>();
    }
}