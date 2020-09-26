using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Data;
using Data.Maintenance;
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

		public IEnumerable<Data.Maintenance.AssetMaterial> AssetMaterials(int nID_Asset)
		{
			StringBuilder oSql = new StringBuilder();
			oSql.AppendLine("SELECT AM.*, M.Name, M.Description FROM Maintenance.AssetMaterials AM");
			oSql.AppendLine("INNER JOIN Maintenance.Materials M ON AM.ID_Material=M.ID_Material");
			oSql.AppendLine("WHERE ID_Asset=" + EntitiesManagerBase.UTI_ValueToSql(nID_Asset));
			return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.AssetMaterial>(oSql.ToString()));
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
		public IEnumerable<Data.Planning.Calendar> Calendars
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Planning.Calendar>("SELECT * FROM [Planning].[Calendars]"));
			}
		}
		public IEnumerable<Data.Config.GeographicCenter> GeographicCenters
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.GeographicCenter>("SELECT * FROM [Config].[GeographicCenters]"));
			}
		}
		public IEnumerable<Data.Config.StoreCenter> StoreCenters
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.StoreCenter>("SELECT * FROM [Config].[StoreCenters]"));
			}
		}
		public IEnumerable<Data.Config.ObjStatuse> ObjStatuses
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.ObjStatuse>("SELECT * FROM [Config].[ObjStatuses]"));
			}
		}
		public IEnumerable<Data.Config.City> Cities { get { return (Data.Config.Citys.GetItalianCitiesForDropDownList()); } }
		public IEnumerable<Data.Config.Country> Countries
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Config.Country>("SELECT * FROM [Config].[Countries]"));
			}
		}
		public IEnumerable<Data.Security.User> Users
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Security.User>("SELECT * FROM [Security].[Users]"));
			}
		}
		public IEnumerable<Data.Maintenance.Material> Materials
		{
			get
			{
				StringBuilder oSql = new StringBuilder();
				oSql.AppendLine("SELECT M.*, S.Name as SupplierName, MUM.Name as MaterialUMName, SC.Name as StoreCenterName, OS.Name as ObjStatusName FROM Maintenance.Materials M");
				oSql.AppendLine("INNER JOIN Config.ObjStatuses OS ON M.ID_ObjStatus=OS.ID_ObjStatus");
				oSql.AppendLine("INNER JOIN Maintenance.Suppliers S ON M.ID_Supplier=S.ID_Supplier");
				oSql.AppendLine("INNER JOIN Maintenance.MaterialUMs MUM ON M.ID_MaterialUM=MUM.ID_MaterialUM");
				oSql.AppendLine("INNER JOIN Config.StoreCenters SC ON M.ID_StoreCenter=SC.ID_StoreCenter");
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.Material>(oSql.ToString()));
			}
		}
		public IEnumerable<Data.Maintenance.MaterialUM> MaterialUMs
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.MaterialUM>("SELECT * FROM [Maintenance].[MaterialUMs]"));
			}
		}
		public IEnumerable<Data.Maintenance.Supplier> Suppliers
		{
			get
			{
				StringBuilder oSql = new StringBuilder();
				oSql.AppendLine("SELECT S.*, ST.Name as SupplierTypeName, OS.Name as ObjStatusName, CC.Name as CostCenterName, C.Name as CityName, CO.Name as CountryName, U.Username as UserName");
				oSql.AppendLine("FROM Maintenance.Suppliers S");
				oSql.AppendLine("INNER JOIN Maintenance.SupplierTypes ST ON S.ID_SupplierType=ST.ID_SupplierType");
				oSql.AppendLine("INNER JOIN Config.ObjStatuses OS ON S.ID_ObjStatus=OS.ID_ObjStatus");
				oSql.AppendLine("INNER JOIN Accountancy.CostCenters CC ON S.ID_CostCenter=CC.ID_CostCenter");
				oSql.AppendLine("INNER JOIN Config.Cities C ON S.ID_City=C.ID_City");
				oSql.AppendLine("INNER JOIN Config.Countries CO ON S.ID_Country=CO.ID_Country");
				oSql.AppendLine("LEFT OUTER JOIN Security.Users U ON S.ID_User=U.ID_User");
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.Supplier>(oSql.ToString()));
			}
		}
		public IEnumerable<Data.Maintenance.SupplierType> SupplierTypes
		{
			get
			{
				return (EntitiesManagerBase.SharedConnection.Query<Data.Maintenance.SupplierType>("SELECT * FROM Maintenance.SupplierTypes"));
			}
		}
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