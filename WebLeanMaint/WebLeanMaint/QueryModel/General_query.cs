using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.QueryModel
{
    public class General_query
    {
        public int ID_Country { get; set; }
        public int ID_City { get; set; }
        public int ID_User { get; set; }
        public int ID_Calendar { get; set; }
        public int ID_StoreCenter { get; set; }
        public int ID_OrganizationCenter { get; set; }
        public int ID_CostCenter { get; set; }
        public int ID_GeographicCenter { get; set; }
        public int ID_ObjStatus { get; set; }
        public int ID_AssetType { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
    }
    public class MaintenanceAssetsQuery
    {
        public int ID_Asset { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_AssetType { get; set; }
        public int ID_OrganizationCenter { get; set; }
        public int? ID_Parent { get; set; }
        public int ID_CostCenter { get; set; }
        public int? ID_GeographicCenter { get; set; }
        public int ID_ObjStatus { get; set; }
        public string AssetType { get; set; }
        public string OrgName { get; set; }
        public string costname { get; set; }
        public string geoname { get; set; }
        public string subname { get; set; }
    }
    public class MaintenanceMaterialsquery
    {
        public int ID_Material { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_ObjStatus { get; set; }
        public string ReferenceCode { get; set; }
        public int ID_Supplier { get; set; }
        public decimal CostPerUM { get; set; }
        public string Brand { get; set; }
        public int ID_MaterialUM { get; set; }
        public int ID_StoreCenter { get; set; }
        public string Type { get; set; }
        public string Barcode { get; set; }
        public string subname { get; set; }
        public string supname { get; set; }
        public string unitname { get; set; }
        public string storename { get; set; }
    }
    public class MaintenanceSuppliersquery
    {
         public int ID_Supplier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_SupplierType { get; set; }
        public int ID_ObjStatus { get; set; }
        public string Address1 { get; set; }
        public int ID_CostCenter { get; set; }
        public string Address2 { get; set; }
        public decimal HourlyCost { get; set; }
        public int ID_City { get; set; }
        public string Zip { get; set; }
        public int ID_Country { get; set; }
        public DateTime ValidFrom { get; set; }
        public int ID_User { get; set; }
        public string subname { get; set; }
        public string suptype { get; set; }
        public string costname { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string username { get; set; }
    }
    public class PlanningOperatorsquery
    {
        public int ID_Operator { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int ID_OperatorType { get; set; }
        public int? ID_Calendar { get; set; }
        public int? ID_Supplier { get; set; }
        public int? ID_CostCenter { get; set; }
        public decimal HourlyCost { get; set; }
        public int ID_ObjStatus { get; set; }
        public int? ID_User { get; set; }
        public string subname { get; set; }
        public string supp  { get; set; }
        public string costname { get; set; }
        public string ptype { get; set; }
        public string cal { get; set; } 
        public string username { get; set; } 
    }
}