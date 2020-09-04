using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLeanMaint.Models;

namespace WebLeanMaint.ViewModels
{
    public class Treeviewmodel
    {
        public IEnumerable<OrganizationCenterTypes> types_list { get; set; }
        public IEnumerable<OrganizationCenters> complete { get; set; }
        public IEnumerable<OrganizationCenters> parent_list { get; set; }
        public IEnumerable<OrganizationCenters> child_list { get; set; }
    }
}