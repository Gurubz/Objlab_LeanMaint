using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebLeanMaint.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AccountancyBilling> tbl_AccountancyBilling { get; set; }
        public DbSet<MaintenanceAssets> tbl_MaintenanceAssets { get; set; }
        public DbSet<MaintenanceAssetTypes> tbl_MaintenanceAssetTypes { get; set; }
        public DbSet<MaintenanceMaterials> tbl_MaintenanceMaterials { get; set; }
        public DbSet<MaintenanceMaterialUMs> tbl_MaintenanceMaterialUMs { get; set; }
        public DbSet<MaintenanceSuppliers> tbl_MaintenanceSuppliers { get; set; }
        public DbSet<MaintenanceSupplierTypes> tbl_MaintenanceSupplierTypes { get; set; }
        public DbSet<PlanningOperators> tbl_PlanningOperators { get; set; }
        public DbSet<PlanningOperatorTypes> tbl_PlanningOperatorTypes { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

     
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}