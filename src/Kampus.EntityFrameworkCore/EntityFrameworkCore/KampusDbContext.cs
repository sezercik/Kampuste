using Kampus.Departments;
using Kampus.Grades;
using Kampus.Universities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Kampus.PostsLikes;
using Kampus.UserFollows;

namespace Kampus.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class KampusDbContext :
    AbpDbContext<KampusDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Department> Departments { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Grade> Grades { get; set; }
    
    public DbSet<UserSettings.UserSetting> UserSettings { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public KampusDbContext(DbContextOptions<KampusDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(KampusConsts.DbTablePrefix + "YourEntities", KampusConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<Grade>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "Grades",
                KampusConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
        
        builder.Entity<University>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "Universities",
                KampusConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
        
        builder.Entity<Department>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "Departments",
                KampusConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });
      
     
        
        builder.Entity<UserSettings.UserSetting>(b =>
        {
            b.ToTable("AppUserSettings");
            b.ConfigureByConvention();
            b.HasOne<IdentityUser>()
                .WithOne()
                .HasForeignKey<UserSettings.UserSetting>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Post>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "Posts",
                KampusConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasOne<IdentityUser>(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
          
            b.HasMany<PostLike>(p => p.PostLikes)
               .WithOne()
               .HasForeignKey(p => p.PostId)
               .OnDelete(DeleteBehavior.NoAction);

        });

        builder.Entity<PostLike>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "PostLikes", KampusConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne<Post>(p => p.Post)
                .WithMany(e => e.PostLikes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(p => p.PostId)
                .IsRequired();

            b.HasOne<IdentityUser>(p => p.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired()
                .HasForeignKey(p => p.UserId);
        });

        builder.Entity<UserFollow>(b =>
        {
            b.ToTable(KampusConsts.DbTablePrefix + "UserFollows", KampusConsts.DbSchema);
            b.ConfigureByConvention();

            b.HasOne<IdentityUser>(uf => uf.Follower)
                .WithMany()
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne<IdentityUser>(uf => uf.Followee)
                .WithMany()
                .HasForeignKey(uf => uf.FolloweeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasQueryFilter(uf => !uf.Follower.IsDeleted && !uf.Followee.IsDeleted);
        });

        builder.Entity<IdentityUser>(b =>
        {

            b.HasOne<UserSettings.UserSetting>()
                .WithOne(us => us.User)
                .HasForeignKey<UserSettings.UserSetting>(us => us.UserId);

            b.HasMany<Post>()
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(p => p.UserId);

            b.HasMany<PostLike>()
            .WithOne(p => p.User)
            .OnDelete(DeleteBehavior.NoAction)
            .HasForeignKey(p => p.UserId);

            b.HasMany<UserFollow>()
            .WithOne(uf => uf.Follower)
            .HasForeignKey(uf => uf.FollowerId)
            .OnDelete(DeleteBehavior.NoAction);

            b.HasMany<UserFollow>()
                .WithOne(uf => uf.Followee)
                .HasForeignKey(uf => uf.FolloweeId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        builder.ConfigureBlobStoring();
        }
}
