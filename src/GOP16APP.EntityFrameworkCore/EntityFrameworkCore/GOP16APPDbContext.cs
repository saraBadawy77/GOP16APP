using GOP16APP.Entities;

using GOP16APP.Entities.Information1;
using GOP16APP.Entities.Information2;
using GOP16APP.Entities.Information3;
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

namespace GOP16APP.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class GOP16APPDbContext :
    AbpDbContext<GOP16APPDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<EventUser> eventUsers { get; set; }
    public DbSet<OrganizationCategory> organizationCategories { get; set; }
    public DbSet<Qualification> qualifications { get; set; }
    public DbSet<Sector> sectors { get; set; }
    public DbSet<EntityInformation>entityInformation{ get; set; }

    public DbSet<Level> levels { get; set; }
    public DbSet<RequestedPavilion> requestedPavilions { get; set; }
    public DbSet<ContactDetails> contactDetails { get; set; }
    


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

    public GOP16APPDbContext(DbContextOptions<GOP16APPDbContext> options)
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

        builder.Entity<OrganizationCategory>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "organizationCategories", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Qualification>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "qualifications", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<EventUser>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "eventUsers", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Sector>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "sectors", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<Level>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "levels", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<RequestedPavilion>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "requestedPavilions", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

        builder.Entity<ContactDetails>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "contactDetails", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });

       

        builder.Entity<EntityInformation>(b =>
        {
            b.ToTable(GOP16APPConsts.DbTablePrefix + "entityInformation", GOP16APPConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
        });


    }
}
