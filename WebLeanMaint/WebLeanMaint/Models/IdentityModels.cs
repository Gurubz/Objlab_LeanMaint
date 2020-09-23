using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data;
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
		public IEnumerable<Data.Maintenance.Asset> Assets
		{
			get
			{
				StringBuilder oSql = new StringBuilder();
				oSql.AppendLine("SELECT ");
				oSql.AppendLine("	A.*,");
				oSql.AppendLine("	ATy.[Name] as AssetTypeName,");
				oSql.AppendLine("	OC.[Name] as OrganizationCenterName,");
				oSql.AppendLine("	CC.[Name] as CostCenterName,");
				oSql.AppendLine("	GC.[Name] as GeographicCenterName,");
				oSql.AppendLine("	OS.[Name] as ObjStatusName,");
				oSql.AppendLine("	A2.[Name] as ParentName");
				oSql.AppendLine("FROM [Maintenance].[Assets] A");
				oSql.AppendLine("INNER JOIN Maintenance.AssetTypes ATy ON A.ID_AssetType=ATy.ID_AssetType");
				oSql.AppendLine("INNER JOIN Config.OrganizationCenters OC ON A.ID_OrganizationCenter=OC.ID_OrganizationCenter");
				oSql.AppendLine("INNER JOIN Accountancy.CostCenters CC ON A.ID_CostCenter=CC.ID_CostCenter");
				oSql.AppendLine("LEFT OUTER JOIN Config.GeographicCenters GC ON A.ID_GeographicCenter=GC.ID_GeographicCenter");
				oSql.AppendLine("INNER JOIN Config.ObjStatuses OS ON A.ID_ObjStatus=OS.ID_ObjStatus");
				oSql.AppendLine("LEFT OUTER JOIN Maintenance.Assets A2 ON A.ID_Parent=A2.ID_Asset");
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.Asset>(oSql.ToString()));
			}
		}
		public IEnumerable<Data.Maintenance.AssetType> AssetTypes
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.AssetType>("SELECT * FROM Maintenance.AssetTypes"));
			}
		}
		public IEnumerable<Data.Config.OrganizationCenter> OrganizationCenters
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.OrganizationCenter>("SELECT * FROM [Config].[OrganizationCenters]"));
			}
		}
		public IEnumerable<Data.Accountancy.CostCenter> CostCenters
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Accountancy.CostCenter>("SELECT * FROM [Accountancy].[CostCenters]"));
			}
		}
		public IEnumerable<Data.Config.GeographicCenter> GeographicCenters
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.GeographicCenter>("SELECT * FROM [Config].[GeographicCenters]"));
			}
		}
		public IEnumerable<Data.Config.ObjStatuse> ObjStatuses
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.ObjStatuse>("SELECT * FROM [Config].[ObjStatuses]"));
			}
		}
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