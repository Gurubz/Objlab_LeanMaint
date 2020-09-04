using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebLeanMaint.Models
{
    public class OrganizationCenters
    {
        public int ID_OrganizationCenter { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_OrganizationCenterType { get; set; }
        public int ID_ObjStatus { get; set; }
        public int? ID_Parent { get; set; }
    }
    public class Users
    {
        public int ID_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string Mobile { get; set; }
        public int Seed { get; set; }
        public int ID_UserType { get; set; }
        public int ID_ObjStatus { get; set; }
    }
}